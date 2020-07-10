using System;

namespace NoName.Framework.Core.Data.Declarations
{
	public interface IDataConverter
	{
		bool GetAsBoolean(object value);

		DateTime GetAsDate(object value);

		DateTime GetAsDateTime(object value);

		decimal GetAsDecimal(object value);

		short GetAsInt16(object value);

		int GetAsInt32(object value);

		long GetAsInt64(object value);

		string GetAsString(object value);
	}
}