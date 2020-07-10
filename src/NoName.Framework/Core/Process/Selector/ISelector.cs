using System.Collections.Generic;

using NoName.Framework.Core.Process.Selector.Entities;

namespace NoName.Framework.Core.Process.Selector
{
	public interface ISelector<T>
	{
		IEnumerable<object> Select(T source, string[] fields, params SelectorCondition<T>[] conditions);
	}
}