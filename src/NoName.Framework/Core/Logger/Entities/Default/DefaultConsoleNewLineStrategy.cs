using System;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Entities.Default
{
	public class DefaultConsoleNewLineStrategy : INewLineStrategy
	{
		public string NewLine => "\n";
	}
}