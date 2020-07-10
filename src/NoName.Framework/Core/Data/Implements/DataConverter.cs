using System;

using NoName.Framework.Core.Data.Declarations;

namespace NoName.Framework.Core.Data.Implements
{
	public class DefaultDataConverter : IDataConverter
	{
		private DefaultDataConverter()
		{
		}

		public static DefaultDataConverter Instance { get; } = new DefaultDataConverter();

		public bool GetAsBoolean(object value)
		{
			if (value is bool result)
			{
				return result;
			}

			return bool.Parse(value.ToString());
		}

		public DateTime GetAsDate(object value)
		{
			if (value is DateTime result)
			{
				return result.Date;
			}

			return DateTime.Parse(value.ToString()).Date;
		}

		public DateTime GetAsDateTime(object value)
		{
			if (value is DateTime result)
			{
				return result;
			}

			return DateTime.Parse(value.ToString());
		}

		public decimal GetAsDecimal(object value)
		{
			if (value is decimal result)
			{
				return result;
			}

			return decimal.Parse(value.ToString());
		}

		public short GetAsInt16(object value)
		{
			if (value is short result)
			{
				return result;
			}

			return short.Parse(value.ToString());
		}

		public int GetAsInt32(object value)
		{
			if (value is int result)
			{
				return result;
			}

			return int.Parse(value.ToString());
		}

		public long GetAsInt64(object value)
		{
			if (value is long result)
			{
				return result;
			}

			return long.Parse(value.ToString());
		}

		public string GetAsString(object value)
		{
			if (value is string result)
			{
				return result;
			}

			return value.ToString();
		}
	}
}