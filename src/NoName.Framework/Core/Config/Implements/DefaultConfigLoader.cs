using NoName.Framework.Core.Config.Declarations;
using NoName.Framework.Core.Config.Declarations.Processors;
using NoName.Framework.Core.File;
using NoName.Framework.Core.File.Declarations;

namespace NoName.Framework.Core.Config.Implements
{
	using Processer = IConfigTextMemoryStreamProcessor<DefaultConfigBuilder, Entities.Config>;

	public class DefaultConfigLoader : IConfigLoader
	{
		private readonly Processer _processor;
		private readonly IFileReaderFactory _factory;

		public DefaultConfigLoader(IFileReaderFactory factory)
		{
			_factory = factory;
			_processor = new ConfigTextMemoryStreamProcessor<DefaultConfigBuilder, Entities.Config>();
		}

		public IConfig LoadConfig(string fileName)
		{
			var fileReader = _factory.LoadFile(fileName);
			return fileReader.Read<Processer, Entities.Config>(_processor);
		}
	}
}