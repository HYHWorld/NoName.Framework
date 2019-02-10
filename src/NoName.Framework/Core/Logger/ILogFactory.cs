using System;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger
{
	public interface ILogFactory
	{
		INewLineStrategy NewLineStrategy { get; set; }

		ITraceFormatStrategy TraceFormatStrategy { get; set; }

		ILogWriterFactory LogWriterFactory { get; set; }

		T Create<T>(String message, Boolean withTrace = false, LogLevel logLevel = LogLevel.Info)
			where T : class, ILog, new();
	}
}
