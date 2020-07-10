using System;

namespace NoName.Framework.Core.Data.Declarations
{
	public interface IFieldValueConverter
	{
		bool GetAsBoolean(string field);

		DateTime GetAsDate(string field);

		DateTime GetAsDateTime(string field);

		decimal GetAsDecimal(string field);

		short GetAsInt16(string field);

		int GetAsInt32(string field);

		long GetAsInt64(string field);

		string GetAsString(string field);
	}
}