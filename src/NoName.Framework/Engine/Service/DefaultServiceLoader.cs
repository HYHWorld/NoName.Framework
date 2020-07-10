using System;
using System.Collections.Generic;

using NoName.Framework.Core.Config.Declarations;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Engine.Service
{
	public class DefaultServiceLoader : IServiceLoader
	{
		public DefaultServiceLoader()
		{
		}

		public IService CurrentService { get; }

		private IConfigLoader ConfigLoader { get; }

		private IDictionary<string, string> Options { get; } = new Dictionary<string, string>();

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			return null;
		}

		public T CreateClient<T>(Func<IDictionary<string, string>> additionalOptions)
			where T : IServiceClient
		{
			return default(T);
		}

		public T CreateClient<T>()
			where T : IServiceClient
		{
			return default(T);
		}

		public IService GetRevision()
		{
			return null;
		}

		public IEnumerable<IService> GetRevisions()
		{
			yield break;
		}

		public void Load()
		{
			// var config = ConfigLoader.GetConfig(typeof(IServiceLoader));

			// 锁
			// Options.Merge(config.GetValues());
			this.Online();
		}

		public void Load(Func<IDictionary<string, string>> extraFunc)
		{
			this.Options.Merge(extraFunc.Invoke());
			this.Load();
		}

		public void Offline()
		{
		}

		public void Online()
		{
		}
	}
}