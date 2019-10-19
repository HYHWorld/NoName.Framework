namespace NoName.Framework.Core.Data.DataStore.Cache
{
    public enum CacheObjectState
    {
        Accessible,  //可以访问
        InUsing,     //正在使用
        UnAccessible //等待释放
    }


    public class CacheKey
    {

        public CacheObjectState State { get; private set; }

        public object Key { get; }


        public CacheKey(object key)
        {
            Key = key;
            State = CacheObjectState.Accessible;
        }

        //  User-defined conversion from double to Digit
        public static implicit operator CacheKey(string key)
        {
            return new CacheKey(key);
        }

    }
}
