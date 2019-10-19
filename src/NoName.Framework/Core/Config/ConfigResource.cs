using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoName.Framework.Core.Attributes.Resource;
using NoName.Framework.Core.Logger;
using NoName.Framework.Core.Resource;
using NoName.Framework.Core.Resource.LocalResource;

namespace NoName.Framework.Core.File.Config
{
    public class ConfigResource : IResource
    {
        private const string ConfigPath = "Config";

        [AssignResource(ResourceName =  "DefaultLogWriter", Type = typeof(ILogFactory))]
        private ILogFactory _logFactory { get; set; }

        private IConfigLoader _configLoader;

        public ConfigResource()
        {
            _configLoader = new ConfigLoader(new FileReaderFactory());
        }

        public void InitializeResource()
        {
	        CreateConfigDirectory();

			foreach (var fileName in Directory.GetFiles(ConfigPath))
			{
				_configLoader.LoadConfig(fileName);
			}
        }

        private void CreateConfigDirectory()
        {
	        if (!Directory.Exists(ConfigPath))
	        {
		        try
		        {
			        Directory.CreateDirectory(ConfigPath);
		        }
		        catch (System.UnauthorizedAccessException e)
		        {

		        }
	        }
        }
    }
}
