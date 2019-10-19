using System.IO;
using System.Threading;

namespace NoName.Framework.Core.Logger
{
    public class FileLogWriter : StreamLogWriter
    {
        public FileLogWriter(string filePath, ILogWriterFactory<ILogWriter> logWriterFactory) : base(new FileStream(filePath, FileMode.Create), logWriterFactory)
        {
            FilePath = filePath;
        }

        private string FilePath { get; }

        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public override void Write()
        {
            _lock.EnterWriteLock();
            base.Write();
            Writer.Close();
            Writer = new StreamWriter(new FileStream(FilePath, FileMode.Append));
            _lock.ExitWriteLock();
        }

    }
}