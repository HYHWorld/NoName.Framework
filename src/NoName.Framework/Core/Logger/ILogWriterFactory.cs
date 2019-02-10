using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger
{
	public interface ILogWriterFactory
	{
		INewLineStrategy NewLineStrategy { get; set; }

		ITraceFormatStrategy TraceFormatStrategy { get; set; }

		ILogWriter CreateLogWriter();

		T CreateLogFactory<T>(INewLineStrategy newLineStrategy, ITraceFormatStrategy traceFormatStrategy) where T : class, ILogFactory, new();
	}
}
