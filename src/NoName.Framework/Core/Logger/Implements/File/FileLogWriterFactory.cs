using NoName.Framework.Core.Logger.Declarations.File;
using NoName.Framework.Core.Logger.Implements.Default;

namespace NoName.Framework.Core.Logger.Implements.File
{
	public class FileLogWriterFactory : DefaultLogWriterFactory<FileLogWriter>, IFileLogWriterFactory
	{
	}
}