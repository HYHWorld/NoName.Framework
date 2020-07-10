using System;
using System.Data;

using NoName.Framework.Core.Data.Declarations;

namespace NoName.Framework.Core.Data.Implements
{
	public partial class DataSetWrapper
	{
		private readonly IDataConverter _dataConverter = DefaultDataConverter.Instance;

		public DataSetWrapper(DataSet set, IDataConverter dataConverter)
			: this(set)
		{
			if (dataConverter != null)
			{
				_dataConverter = dataConverter;
			}
		}

		public bool GetAsBoolean(string field)
		{
			return _dataConverter.GetAsBoolean(this[field]);
		}

		public DateTime GetAsDate(string field)
		{
			return _dataConverter.GetAsDate(this[field]);
		}

		public DateTime GetAsDateTime(string field)
		{
			return _dataConverter.GetAsDateTime(this[field]);
		}

		public decimal GetAsDecimal(string field)
		{
			return _dataConverter.GetAsDecimal(this[field]);
		}

		public short GetAsInt16(string field)
		{
			return _dataConverter.GetAsInt16(this[field]);
		}

		public int GetAsInt32(string field)
		{
			return _dataConverter.GetAsInt32(this[field]);
		}

		public long GetAsInt64(string field)
		{
			return _dataConverter.GetAsInt32(this[field]);
		}

		public string GetAsString(string field)
		{
			return _dataConverter.GetAsString(this[field]);
		}
	}
}