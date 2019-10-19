namespace NoName.Framework.Core.Data.DataStore.Cache
{
    public class DefaultCache : ICache
    {
        public void Add(CacheKey key, object obj)
        {
        }

        public object this[CacheKey key] => null;
    }
}
