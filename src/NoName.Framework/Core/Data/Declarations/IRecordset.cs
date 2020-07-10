using System.Collections.Generic;

namespace NoName.Framework.Core.Data.Declarations
{
	public interface IRecordset : IFieldValueConverter, IEnumerable<IRecordsetRow>
	{
		void AddNew();

		void AddNewGroup();

		void Remove();

		void RemoveGroup();
	}
}