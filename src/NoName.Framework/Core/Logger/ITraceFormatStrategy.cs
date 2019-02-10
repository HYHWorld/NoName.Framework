using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NoName.Framework.Core.Logger
{
	public interface ITraceFormatStrategy
	{
		String FormatTrace(StackTrace trace);
	}
}
