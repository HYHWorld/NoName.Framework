using System;
using System.Collections.Generic;
using System.Text;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.DefaultSettings
{
	public class DefaultNewLineStrategy:INewLineStrategy
	{
		public String NewLine => "\r\n";
	}
}
