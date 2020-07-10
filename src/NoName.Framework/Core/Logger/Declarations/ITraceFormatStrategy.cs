using System;
using System.Diagnostics;

namespace NoName.Framework.Core.Logger.Declarations
{
	public interface ITraceFormatStrategy
	{
		string FormatTrace(StackTrace trace);
	}
}