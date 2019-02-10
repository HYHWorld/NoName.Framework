using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.DefaultSettings
{
	public class DefaultLogFactory : ILogFactory
	{
		public DefaultLogFactory(ILogWriterFactory logWriterFactory)
		{
			LogWriterFactory = logWriterFactory;
		}

		public INewLineStrategy NewLineStrategy { get; set; }

		public ITraceFormatStrategy TraceFormatStrategy { get; set; }

		public ILogWriterFactory LogWriterFactory { get; set; }

		public T Create<T>(String message, Boolean withTrace = false, LogLevel logLevel = LogLevel.Info)
			where T : class, ILog, new()
		{
			var log = CreateLog<T>(message, logLevel);

			//maybe other newer fashionable trace style/format? 
			//does it necessary to add a factory to create different style of trace?...
			if (withTrace)
			{
				var trace = new StackTrace(1, true);
				log.Trace          = trace;
				log.FormattedTrace = TraceFormatStrategy.FormatTrace(trace);
			}

			log.FallMassage = FormatMessage(log);

			return log;
		}

		private T CreateLog<T>(String message, LogLevel logLevel) where T : class, ILog, new()
		{
			return new T
			{
				IsOccurenceTimeEnable = false,
				IsTraceEnable         = false,
				Message               = message,
				OccurrenceTime        = DateTime.Now,
				ReDisplay             = false,
				SubMessage            = null,
				ThreadId              = Thread.CurrentThread.ManagedThreadId,
				LogLevel              = logLevel
			};
		}

		private String FormatMessage(ILog log)
		{
			var builder = new StringBuilder();
			builder.Append($"{log.ThreadId}:[]{log.Message}");

			if (log.IsOccurenceTimeEnable)
				builder.Append($"[{log.OccurrenceTime:yyyy-mm-dd hh:mm:ss}]");

			if (!String.IsNullOrEmpty(log.SubMessage))
				builder.Append($"({log.SubMessage})");

			builder.Append(NewLineStrategy.NewLine);

			if (log.IsTraceEnable)
				builder.Append(log.FormattedTrace);

			return builder.ToString();
		}
	}
}
