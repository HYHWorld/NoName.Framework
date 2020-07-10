using System.Data;

using NoName.Framework.Core.Data.Declarations;
using NoName.Framework.Core.Data.Entities;
using NoName.Framework.Core.Data.Implements.Factory;
using NoName.Framework.Core.Inerfaces;

namespace NoName.Framework.Core.Data.Implements
{
	public partial class Recordset
	{
		public Recordset()
			: this(RecordsetType.DataSet, null)
		{
		}

		public Recordset(RecordsetType recordsetType)
			: this(recordsetType, null)
		{
		}

		public Recordset(IDataConverter dataConverter)
			: this(RecordsetType.DataSet, dataConverter)
		{
		}

		public Recordset(RecordsetType recordsetType, IDataConverter dataConverter)
			: this(null, recordsetType, dataConverter)
		{
		}

		public Recordset(object dataSource)
			: this(dataSource, MapDataSourcetToRecordsetType(dataSource), null)
		{
		}

		public Recordset(object dataSource, IDataConverter dataConverter)
			: this(dataSource, MapDataSourcetToRecordsetType(dataSource), dataConverter)
		{
		}

		public Recordset(object dataSource, RecordsetType recordsetType, IDataConverter dataConverter)
		{
			RecordsetType = recordsetType;
			_wrapper = BuildSetWrapper(recordsetType, dataSource);
			InternalData = new InternalData();

			if (dataConverter != null)
			{
				_dataConverter = dataConverter;
			}
		}

		public RecordsetType RecordsetType { get; }

		private static ISetWrapper BuildSetWrapper(RecordsetType recordsetType, object dataSource = null)
		{
			IFactory<ISetWrapper> factory = new SetWrapperFactory();
			var parameter = dataSource == null ? null : new SetWrapperFactoryProduceParameter() { DataSource = dataSource };

			switch (recordsetType)
			{
				case RecordsetType.DataSet:
					return factory.Produce<DataSetWrapper>(() => parameter);
			}

			return null;
		}

		private static RecordsetType MapDataSourcetToRecordsetType(object dataSource)
		{
			if (dataSource is DataSet)
			{
				return RecordsetType.DataSet;
			}

			return RecordsetType.NotSpecified;
		}
	}
}