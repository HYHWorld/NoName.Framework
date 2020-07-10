using System;
using System.Collections.Generic;
using System.IO;

using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Logger.Entities.Default;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Implements.Stream
{
	public class StreamLogWriter : ILogWriter
	{
		private StreamWriter _writer;

		public StreamLogWriter(System.IO.Stream stream)
			: this(stream, new DefaultFileNewLineStrategy(), new DefaultMessageFormatStrategy())
		{
		}

		public StreamLogWriter(System.IO.Stream stream, INewLineStrategy newLineStrategy, IMessageFormatStrategy messageFormatStrategy)
		{
			if (stream == null || stream.Equals(System.IO.Stream.Null))
			{
				throw new ArgumentNullException(nameof(stream), "not available to operate with a null stream");
			}

			this.NewLineStrategy = newLineStrategy;
			this.MessageFormatStrategy = messageFormatStrategy;
			this._writer = new StreamWriter(stream);
			this._writer.AutoFlush = true;
			this.Items = new LogCollection();
		}

		public LogCollection Items { get; }

		public IMessageFormatStrategy MessageFormatStrategy { get; set; }

		public INewLineStrategy NewLineStrategy { get; set; }

		protected StreamWriter Writer
		{
			get => this._writer;
			set => this._writer = value;
		}

		public void AddLog(ILog log)
		{
			this.Items.AddLog(log);
		}

		public void AddLogs(IEnumerable<ILog> logs)
		{
			this.Items.AddLogs(logs);
		}

		public void Close()
		{
			this._writer.Close();
		}

		public virtual void Write()
		{
			foreach (var item in this.Items) this._writer.Write(this.MessageFormatStrategy.FormatMessage(item, this.NewLineStrategy));
			this._writer.Write(this.NewLineStrategy.NewLine);
		}
	}
}