namespace NoName.Framework.Core.Data.Declarations.DataStore.Cache
{
	public interface ICache
	{
		object this[CacheKey key] { get; }

		// 可多线程访问，根据数据的状态进行获取
		void Add(CacheKey key, object obj);
	}
}