using System;
using System.Collections.Generic;

using NoName.Framework.Core.Data.Implements;

namespace NoName.Framework.Core.Data.Declarations
{
	public interface ISetWrapper
	{
		IList<Field> Fields { get; }

		Type Type { get; }

		object this[string key] { get; set; }

		object this[int index] { get; set; }

		void AddNew();

		void AddNewGroup();

		void Remove();

		void RemoveGroup();

		bool MoveNext();

		bool MoveNextGroup();
	}
}