using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.Framework.Core.Data.Implements
{
	public class Field
	{
		public string Name { get; set; }

		public Type FieldType { get; set; }

		public int Index { get; set; }

		public bool IsReadOnly { get; set; }

		public bool IsAutoIncrement { get; set; }
	}
}
