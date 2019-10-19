using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.Util
{
    public static class DictionaryExtra
    {
        public static IDictionary<String, String> Merge(this IDictionary<String, String> source, IDictionary<String, String> additional)
        {
            foreach (var item in additional)
            {
                if (source.ContainsKey(item.Key))
                {
                    source[item.Key] = additional[item.Key];
                }
                else
                {
                    source.Add(item.Key, item.Value);
                }
            }

            return source;
        }
    }
}
