using NoName.Framework.Engine.Component;
using System.Collections.Generic;

namespace NoName.Framework.Engine.Plugin
{
    public interface IPlugin
    {
        ISet<IComponent> Components { get; set; }

        T FindComponent<T>() where T : IComponent;
    }
}
