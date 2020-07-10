using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NoName.Framework.Core.Data.Implements
{
	public partial class Recordset
	{ 
		public static implicit operator Recordset(DataSet value)
		{
			return new Recordset(value);
		}
    }
}
