using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoName.Framework.Core.Resource;
using NoName.Framework.Core.Resource.LocalResource;

namespace NoName.Framework.Core.Configure
{
    public class ConfigureResource : ISharedResource
    {
        private ConfigureLoader _configureLoader;
        public ConfigureResource()
        {
            _configureLoader = new ConfigureLoader();
        }

        public void InitializeResource()
        {
            _configureLoader.
        }
    }
}
