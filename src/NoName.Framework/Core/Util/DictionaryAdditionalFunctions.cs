using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.Util
{
	public static class DictionaryExtra
	{
		public static IDictionary<string, string> Merge(this IDictionary<string, string> source, IDictionary<string, string> additional)
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