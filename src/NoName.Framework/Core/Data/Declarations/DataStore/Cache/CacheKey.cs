namespace NoName.Framework.Core.Data.Declarations.DataStore.Cache
{
	public enum CacheObjectState
	{
		Accessible, // 可以访问

		InUsing, // 正在使用

		UnAccessible // 等待释放
	}

	public class CacheKey
	{
		public CacheKey(object key)
		{
			this.Key = key;
			this.State = CacheObjectState.Accessible;
		}

		public object Key { get; }

		public CacheObjectState State { get; private set; }

		// User-defined conversion from double to Digit
		public static implicit operator CacheKey(string key)
		{
			return new CacheKey(key);
		}
	}
}