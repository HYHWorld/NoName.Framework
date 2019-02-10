using System;
using System.IO;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger
{
	public class StreamLogWriterFactory : ILogWriterFactory
	{
		public INewLineStrategy NewLineStrategy { get; set; }

		public ITraceFormatStrategy TraceFormatStrategy { get; set; }

		public ILogWriter CreateLogWriter()
		{
			throw new NotImplementedException(
			                                  "this method is observed in StreamLogWriterFactory, you should use ILogWriter Create(Stream stream) instead"
			                                 );
		}

		public T CreateLogFactory<T>(INewLineStrategy newLineStrategy, ITraceFormatStrategy traceFormatStrategy)
			where T : class, ILogFactory, new()
		{
			return new T
			{
				NewLineStrategy     = newLineStrategy,
				TraceFormatStrategy = traceFormatStrategy
			};
		}

		public ILogWriter Create(Stream stream)
		{
			return new StreamLogWriter(stream, this);
		}
	}
}
