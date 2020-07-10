using System.IO;
using System.Threading;

using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Logger.Implements.Stream;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Implements.File
{
	public class FileLogWriter : StreamLogWriter
	{
		private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

		public FileLogWriter(string filePath)
			: base(new FileStream(filePath, FileMode.Create))
		{
			this.FilePath = filePath;
		}

		public FileLogWriter(string filePath, INewLineStrategy newLineStrategy, IMessageFormatStrategy messageFormatStrategy)
			: base(new FileStream(filePath, FileMode.Create), newLineStrategy, messageFormatStrategy)
		{
			this.FilePath = filePath;
		}

		private string FilePath { get; }

		public override void Write()
		{
			this._lock.EnterWriteLock();
			base.Write();
			this.Writer.Close();
			this.Writer = new StreamWriter(new FileStream(this.FilePath, FileMode.Append));
			this._lock.ExitWriteLock();
		}
	}
}