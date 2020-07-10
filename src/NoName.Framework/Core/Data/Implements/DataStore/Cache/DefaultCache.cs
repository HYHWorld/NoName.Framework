using NoName.Framework.Core.Data.Declarations.DataStore.Cache;

namespace NoName.Framework.Core.Data.Implements.DataStore.Cache
{
	public class DefaultCache : ICache
	{
		public object this[CacheKey key] => null;

		public void Add(CacheKey key, object obj)
		{
		}
	}
}