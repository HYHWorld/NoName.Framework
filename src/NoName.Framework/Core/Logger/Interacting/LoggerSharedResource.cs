using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Logger.Implements.File;
using NoName.Framework.Core.Resource.LocalResource;

namespace NoName.Framework.Core.Logger.Interacting
{
	public class LoggerSharedResource : ISharedResource
	{
		private readonly ILogWriterFactory<FileLogWriter> fileLogWriterFactory;

		private string _logFilePath = "log";

		public LoggerSharedResource()
		{
			this.fileLogWriterFactory = new FileLogWriterFactory();
		}

		public ILogWriter LocalLog { get; set; }

		public void InitializeResource()
		{
			this.LocalLog = this.fileLogWriterFactory.CreateLogWriter(this.LocalLog, this.fileLogWriterFactory);
		}
	}
}