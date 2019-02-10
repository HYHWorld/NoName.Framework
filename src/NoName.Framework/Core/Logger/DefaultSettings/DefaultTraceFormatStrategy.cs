using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NoName.Framework.Core.Logger.DefaultSettings
{
	public class DefaultTraceFormatStrategy : ITraceFormatStrategy
	{
		public String FormatTrace(StackTrace trace) => trace.ToString();
	}
}
