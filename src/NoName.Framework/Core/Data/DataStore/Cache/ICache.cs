namespace NoName.Framework.Core.Data.DataStore.Cache
{
    public interface ICache
    {

        //可多线程访问，根据数据的状态进行获取
        void Add(CacheKey key, object obj);

        object this[CacheKey key] { get; }


    }
}
