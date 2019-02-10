using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace NoName.Framework.Core.Logger
{
	public class StreamLogWriter : ILogWriter
	{
		private readonly StreamWriter _writer;

		public StreamLogWriter(Stream stream, ILogWriterFactory factory)
		{
			if (stream == null ||
			    stream.Equals(Stream.Null))
				throw new ArgumentNullException(nameof(stream), "not available to operate with a null stream");

			_writer = new StreamWriter(stream);
			Factory = factory;
			Items   = new LogCollection();
		}

		public ILogWriterFactory Factory { get; }

		public LogCollection Items { get; }

		public void AddLog(ILog log) => Items.AddLog(log);
		public void AddLogs(IEnumerable<ILog> logs) => Items.AddLogs(logs);

		public void Write()
		{
			foreach (var item in Items)
			{
				_writer.WriteAsync(item.FallMassage);
			}
		}
	}
}
