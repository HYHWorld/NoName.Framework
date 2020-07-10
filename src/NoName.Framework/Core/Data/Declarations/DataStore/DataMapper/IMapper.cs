using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.Data.Declarations.DataStore.DataMapper
{
	public interface IMapper<T>
	{
		IEnumerable<Action<T>> Roles { get; }
	}
}