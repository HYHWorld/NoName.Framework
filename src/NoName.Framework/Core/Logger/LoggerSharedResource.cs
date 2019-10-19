using NoName.Framework.Core.Resource;
using NoName.Framework.Core.Resource.LocalResource;

namespace NoName.Framework.Core.Logger
{
    public class LoggerSharedResource : ISharedResource
    {
        private readonly ILogWriterFactory<FileLogWriter> fileLogWriterFactory;
        private string LogFilePath = "log";

        public LoggerSharedResource()
        {
            fileLogWriterFactory = new FileLogWriterFactory();
        }

        public ILogWriter LocalLog { get; set; }

        public void InitializeResource()
        {
            LocalLog = fileLogWriterFactory.CreateLogWriter(LocalLog, fileLogWriterFactory);
        }
    }
}