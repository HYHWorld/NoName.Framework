using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.File.Config
{
    public interface IConfig
    {

	    string GetValue(string key);

        IDictionary<string, string> GetValues();
    }
}
