using NoName.Framework.Core.Data;
using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.File.Config
{
    public class Config : IConfig
    {
        private Recordset _recordset;

        public string GetValue(string key)
        {
	        return _recordset[key];

        }

        public IDictionary<string, string> GetValues()
        {
            return null;
        }
    }
}
