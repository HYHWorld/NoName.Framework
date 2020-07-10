using System;
using System.IO;

using NoName.Framework.Core.File.Declarations;
using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Logger.Declarations.Console;
using NoName.Framework.Core.Stream.Declarations;

namespace NoName.Framework.Core.File.Implements.Binary
{
	public class BinaryFileReader : IFileReader
	{
		private const int BufferLen = 1024;

		// Resource
		private readonly IConsoleLogWriter _consoleLogWriter;

		private readonly ILogFactory _logFactory;

		private readonly BinaryReader _reader;

		public BinaryFileReader(string fileName)
		{
			this._reader = new BinaryReader(new FileStream(fileName, FileMode.Open));
		}

		public MemoryStream Read()
		{
			try
			{
				var buffer = new byte[1024];
				var len = 0;
				var outputStream = new MemoryStream();
				var writer = new BinaryWriter(outputStream);
				while ((len = this._reader.Read(buffer, len, BufferLen)) != 0)
				{
					writer.Write(buffer);
				}

				return outputStream;
			}
			catch (System.Exception)
			{
				// logWriter.AddLog(logWriter.Create<DefaultLog>(e.Message, true, LogLevel.Error));
			}
			finally
			{
				this._reader.Close();
			}

			return default;
		}

		public T Read<T>(Func<MemoryStream, T> process)
		{
			var stream = this.Read();
			return process(stream);
		}

		public TR Read<TP, TR>(TP processor)
			where TP : IStreamProcessor<MemoryStream, TR>
		{
			var stream = this.Read();
			return processor.Process(stream);
		}
	}
}