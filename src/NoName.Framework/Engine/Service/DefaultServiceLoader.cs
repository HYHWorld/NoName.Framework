using NoName.Framework.Core.File.Config;
using NoName.Framework.Core.Util;
using System;
using System.Collections.Generic;

namespace NoName.Framework.Engine.Service
{
    public class DefaultServiceLoader : IServiceLoader
    {
        private IConfigLoader ConfigLoader { get; }

        private IDictionary<string, string> Options { get; } = new Dictionary<string, string>();


        public DefaultServiceLoader()
        {

        }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return null;
        }

        public IService CurrentService { get; }

        public T CreateClient<T>(Func<IDictionary<string, string>> additionalOptions) where T : IServiceClient
        {
            return default(T);
        }

        public T CreateClient<T>() where T : IServiceClient
        {
            return default(T);
        }

        public void Load()
        {
            var config = ConfigLoader.GetConfig(typeof(IServiceLoader));

            // 锁
            Options.Merge(config.GetValues());


            Online();
        }

        public void Offline()
        {

        }

        public IEnumerable<IService> GetRevisions()
        {
            yield break;
        }

        public IService GetRevision()
        {
            return null;
        }

        public void Load(Func<IDictionary<string, string>> extraFunc)
        {
            Options.Merge(extraFunc.Invoke());
            Load();
        }

        public void Online()
        {

        }
    }
}