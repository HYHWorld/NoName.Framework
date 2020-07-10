using System;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Entities.Default
{
	public class DefaultFileNewLineStrategy : INewLineStrategy
	{
		public string NewLine => "\r\n";
	}
}