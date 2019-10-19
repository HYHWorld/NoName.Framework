using System.Collections.Generic;

namespace NoName.Framework.Core.Proxy
{
    public class ProxyAdditionalActionParameter
    {
        private readonly IDictionary<string, object> _parameters;

        public ProxyAdditionalActionParameter()
        {
            _parameters = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get => _parameters[key];
            set => _parameters[key] = value;
        }

        public void TryGetValue(string key, out object value)
        {
            _parameters.TryGetValue(key, out value);
        }

        public T GetValue<T>(string key)
        {
            TryGetValue(key, out var obj);
            return (T)obj;
        }
    }
}