using System;
using System.Diagnostics;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger
{
	/// <summary>
	///     This is the interface for normal log record.
	///     Please extern it if you want to define any new style of log.
	/// </summary>
	public interface ILog
	{

		Boolean ReDisplay { set; get; }

		String Message { get; set; }

		String SubMessage { get; set; }

		StackTrace Trace { get; set; }

		String FormattedTrace { get; set; }

		DateTime OccurrenceTime { get; set; }

		Boolean IsTraceEnable { get; set; }

		Boolean IsOccurenceTimeEnable { get; set; }

		Int32 ThreadId { get; set; }

		String FallMassage { get; set; }

		LogLevel LogLevel { get; set; }
	}
}
