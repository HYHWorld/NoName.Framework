using System;
using System.Collections.Generic;

using NoName.Framework.Core.Config.Declarations;

namespace NoName.Framework.Core.Config.Implements
{
	public class DefaultConfigBuilder : IConfigBuilder<Entities.Config>
	{
		public Entities.Config Build(IDictionary<string, object> data)
		{
			throw new NotImplementedException();
		}
	}
}