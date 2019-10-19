using System;

namespace NoName.Framework.Core.File.Config
{
    public interface IConfigLoader
    {
        IConfig LoadConfig(string fileName);
    }
}
