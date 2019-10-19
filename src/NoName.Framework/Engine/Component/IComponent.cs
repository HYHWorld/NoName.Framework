using NoName.Framework.Core.Resource;
using System.Collections.Generic;
using NoName.Framework.Core.Resource.PublicResource;

namespace NoName.Framework.Engine.Component
{
    public interface IComponent : IUniqueResource
    {

        IComponent ParentComponent { get; set; }

        ISet<IComponent> ChildComponents { get; set; }

        void OnCreate();

        void OnLoadResource();

        void OnDestroy();
    }
}
