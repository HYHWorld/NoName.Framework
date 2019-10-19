using System;
using System.Collections.Generic;
using System.Linq;
using NoName.Framework.Core.Resource.LocalResource;

namespace NoName.Framework.Core.Resource
{
    public class ResourceLocator
    {

        public static readonly ResourceLocator Instance = new ResourceLocator();

        private ResourceLocator()
        {
        }

        public SharedResourceLocator SharedResource = new SharedResourceLocator();

        public class SharedResourceLocator
        {
            private IList<ISharedResource> resources;

            public SharedResourceLocator()
            {
                LoadResource();
            }
            private void LoadResource()
            {
                //
                foreach (var typeInfo in GetType().Assembly.DefinedTypes)
                {
                    var res = typeInfo.GetInterfaces().FirstOrDefault(t => t == typeof(ISharedResource));
                    if (res == null) continue;
                    resources.Add((ISharedResource)Activator.CreateInstance(res));
                }

                foreach (var res in resources) res.InitializeResource();
            }

            public T Resolve<T>()
            {
                return (T)resources.FirstOrDefault(t => t is T);
            }
        }
    }
}