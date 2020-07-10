using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.Framework.Core.Inerfaces
{
	public interface IFactoryProduceParameter
	{
		Dictionary<string, object> Parameters { get; }

		object this[string key] { get; set; }
	}
}
