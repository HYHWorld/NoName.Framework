namespace NoName.Framework.Core.Data.Declarations.DataStore.Cache
{
	public interface ICacheFactory
	{
		ICache CreateCache(CreateCacheOption option);
	}
}