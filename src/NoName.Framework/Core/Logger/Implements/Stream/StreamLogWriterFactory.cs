using System;

using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Logger.Declarations.Stream;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Implements.Stream
{
	public class StreamLogWriterFactory : IStreamLogWriterFactory
	{
		public T CreateLogFactory<T>(INewLineStrategy newLineStrategy, ITraceFormatStrategy traceFormatStrategy, IMessageFormatStrategy messageFormatStrategy)
			where T : class, ILogFactory, new()
		{
			return new T { NewLineStrategy = newLineStrategy, TraceFormatStrategy = traceFormatStrategy, MessageFormatStrategy = messageFormatStrategy };
		}

		public ILogWriter CreateLogWriter(params object[] constructorParamList)
		{
			// The length here should same to the number of parameter the StreamLogWriter needs.
			if (constructorParamList.Length == 1 || constructorParamList.Length == 3)
			{
				return Activator.CreateInstance(typeof(StreamLogWriter), constructorParamList) as ILogWriter;
			}

			throw new ArgumentException("The number of parameter to create the Instance for the StreamLogWriter does not match the defines");
		}
	}
}