using System.Collections.Generic;

namespace NoName.Framework.Core.Config.Declarations
{
	public interface IConfigBuilder<out TO>
		where TO : IConfig
	{
		TO Build(IDictionary<string, object> data);
	}
}