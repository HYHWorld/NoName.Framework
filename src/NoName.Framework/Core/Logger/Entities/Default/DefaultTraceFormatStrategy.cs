using System;
using System.Diagnostics;

using NoName.Framework.Core.Logger.Declarations;

namespace NoName.Framework.Core.Logger.Entities.Default
{
	public class DefaultTraceFormatStrategy : ITraceFormatStrategy
	{
		public string FormatTrace(StackTrace trace) => trace.ToString();
	}
}