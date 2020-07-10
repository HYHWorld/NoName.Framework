using System;
using System.Diagnostics;
using System.Threading;

using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Implements.Default
{
	public class DefaultLogFactory : ILogFactory
	{
		public IMessageFormatStrategy MessageFormatStrategy { get; set; }

		public INewLineStrategy NewLineStrategy { get; set; }

		public ITraceFormatStrategy TraceFormatStrategy { get; set; }

		public T Create<T>(string message, ILogAdditionalData logAdditionalData)
			where T : class, ILog, new()
		{
			var log = this.CreateLog<T>(message, logAdditionalData);

			// maybe other newer fashionable trace style/format? 
			// does it necessary to add a factory to create different style of trace?...
			var trace = new StackTrace(1, true);
			log.Trace = trace;
			if (this.TraceFormatStrategy != null)
			{
				log.FormattedTrace = this.TraceFormatStrategy.FormatTrace(trace);
			}

			return log;
		}

		private T CreateLog<T>(string message, ILogAdditionalData logAdditionalData)
			where T : class, ILog, new()
		{
			return new T
				       {
					       Message = message,
					       OccurrenceTime = DateTime.Now,
					       ReDisplay = false,
					       SubMessage = null,
					       ThreadId = Thread.CurrentThread.ManagedThreadId,
					       MessagePrefix = Thread.CurrentThread.ManagedThreadId.ToString(),
					       AdditionalData = logAdditionalData
				       };
		}
	}
}