using System.Collections.Generic;

using NoName.Framework.Core.Resource.PublicResource;

namespace NoName.Framework.Engine.Component
{
	public interface IComponent : IUniqueResource
	{
		ISet<IComponent> ChildComponents { get; set; }

		IComponent ParentComponent { get; set; }

		void OnCreate();

		void OnDestroy();

		void OnLoadResource();
	}
}