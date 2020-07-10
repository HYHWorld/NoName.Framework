using System.Collections.Generic;

using NoName.Framework.Core.Data.Declarations;

namespace NoName.Framework.Core.Data.Implements
{
	public class InternalData : IInternalData
	{
		private IDictionary<string, object> _data;

		public InternalData()
		{
			this._data = new Dictionary<string, object>();
		}

		public string UserMessage
		{
			get => this["UserMessage"] as string;
			set => this["UserMessage"] = value;
		}

		public object this[string key]
		{
			get
			{
				if (this._data != null && this._data.ContainsKey(key))
				{
					return this._data[key];
				}

				return null;
			}

			set
			{
				if (this._data != null && this._data.ContainsKey(key))
				{
					this._data[key] = value;
				}

				this._data?.Add(key, value);
			}
		}
	}
}