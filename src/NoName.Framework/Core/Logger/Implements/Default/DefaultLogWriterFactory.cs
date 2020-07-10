using System;

using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Implements.Default
{
	public class DefaultLogWriterFactory<TW> : ILogWriterFactory<TW>
		where TW : class, ILogWriter
	{
		public T CreateLogFactory<T>(INewLineStrategy newLineStrategy, ITraceFormatStrategy traceFormatStrategy, IMessageFormatStrategy messageFormatStrategy)
			where T : class, ILogFactory, new()
		{
			return new T { NewLineStrategy = newLineStrategy, TraceFormatStrategy = traceFormatStrategy, MessageFormatStrategy = messageFormatStrategy };
		}

		public ILogWriter CreateLogWriter(params object[] constructorParamList)
		{
			return Activator.CreateInstance(typeof(TW), constructorParamList) as ILogWriter;
		}
	}
}