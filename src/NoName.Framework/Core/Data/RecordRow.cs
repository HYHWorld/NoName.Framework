using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.Framework.Core.Data
{
	public class RecordRow : IRecordRow
	{
		private Dictionary<string, object> _row { get; set; }

		public object this[string key] {
			get
			{
				if (_row != null && _row.ContainsKey(key))
				{
					return _row[key];
				}

				throw new KeyNotFoundException("Key doesn't contain the specific key");
			}

		}
	}
}
