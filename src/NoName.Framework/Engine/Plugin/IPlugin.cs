using System.Collections.Generic;

using NoName.Framework.Engine.Component;

namespace NoName.Framework.Engine.Plugin
{
	public interface IPlugin
	{
		ISet<IComponent> Components { get; set; }

		T FindComponent<T>()
			where T : IComponent;
	}
}