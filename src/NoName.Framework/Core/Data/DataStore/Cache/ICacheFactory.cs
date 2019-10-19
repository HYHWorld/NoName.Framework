namespace NoName.Framework.Core.Data.DataStore.Cache
{
    public interface ICacheFactory
    {
        ICache CreateCache(CreateCacheOption option);
    }
}
