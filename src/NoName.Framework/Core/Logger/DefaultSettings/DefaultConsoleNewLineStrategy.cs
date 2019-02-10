using System;
using System.Collections.Generic;
using System.Text;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.DefaultSettings
{
	public class DefaultConsoleNewLineStrategy	:INewLineStrategy
	{
		public String NewLine => "\n";
	}
}
