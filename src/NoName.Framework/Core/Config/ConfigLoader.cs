using System;

namespace NoName.Framework.Core.File.Config
{
    public class ConfigLoader : IConfigLoader
    {
        private IFileReaderFactory Factory { get; }

        public ConfigLoader(IFileReaderFactory factory)
        {
            Factory = factory;
        }

        public IConfig LoadConfig(string fileName)
        {
	        var fileReader = Factory.LoadFile(fileName);
	        fileReader.Read<>()

		}
    }
}