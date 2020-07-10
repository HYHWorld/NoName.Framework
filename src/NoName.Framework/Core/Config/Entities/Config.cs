using System;
using System.Collections.Generic;

using NoName.Framework.Core.Config.Declarations;
using NoName.Framework.Core.Data;
using NoName.Framework.Core.Data.Implements;

namespace NoName.Framework.Core.Config.Entities
{
	public class Config : Recordset, IConfig
	{
		private Recordset _recordset;

		public object GetValue(string key)
		{
			return this._recordset[key];
		}

		public IDictionary<string, object> GetValues()
		{
			return null;
		}

		public void SetValue(string key, string value, Type selector)
		{
		}
	}
}