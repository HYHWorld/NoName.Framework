using System.Collections.Generic;

namespace NoName.Framework.Core.Config.Declarations
{
	public interface IConfig
	{
		object GetValue(string key);

		IDictionary<string, object> GetValues();
	}
}