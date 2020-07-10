using System.Collections.Generic;

namespace NoName.Framework.Core.Proxy
{
	public class ProxyAdditionalActionParameter
	{
		private readonly IDictionary<string, object> _parameters;

		public ProxyAdditionalActionParameter()
		{
			this._parameters = new Dictionary<string, object>();
		}

		public object this[string key]
		{
			get => this._parameters[key];
			set => this._parameters[key] = value;
		}

		public T GetValue<T>(string key)
		{
			this.TryGetValue(key, out var obj);
			return (T)obj;
		}

		public void TryGetValue(string key, out object value)
		{
			this._parameters.TryGetValue(key, out value);
		}
	}
}