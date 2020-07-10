using System;
using System.Collections.Generic;
using System.Linq;

using NoName.Framework.Core.Resource.LocalResource;

namespace NoName.Framework.Core.Resource
{
	public class ResourceLocator
	{
		public static readonly ResourceLocator Instance = new ResourceLocator();

		private SharedResourceLocator _sharedResource;

		private ResourceLocator()
		{
			this._sharedResource = new SharedResourceLocator();
		}

		public class SharedResourceLocator
		{
			private IList<ISharedResource> resources;

			public SharedResourceLocator()
			{
				this.LoadResource();
			}

			public T Resolve<T>()
			{
				return (T)this.resources.FirstOrDefault(t => t is T);
			}

			private void LoadResource()
			{
				foreach (var typeInfo in this.GetType().Assembly.DefinedTypes)
				{
					var res = typeInfo.GetInterfaces().FirstOrDefault(t => t == typeof(ISharedResource));
					if (res == null) continue;
					this.resources.Add((ISharedResource)Activator.CreateInstance(res));
				}

				foreach (var res in this.resources) res.InitializeResource();
			}
		}
	}
}