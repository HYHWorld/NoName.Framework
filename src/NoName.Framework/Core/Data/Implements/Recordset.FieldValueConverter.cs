using System;

using NoName.Framework.Core.Data.Declarations;
using NoName.Framework.Core.Data.Entities;

namespace NoName.Framework.Core.Data.Implements
{
	public partial class Recordset : IFieldValueConverter
	{
		private readonly IDataConverter _dataConverter = DefaultDataConverter.Instance;

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