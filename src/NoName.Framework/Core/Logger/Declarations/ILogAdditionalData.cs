using NoName.Framework.Core.Logger.Entities;

namespace NoName.Framework.Core.Logger.Declarations
{
	public interface ILogAdditionalData
	{
		bool IsLevelEnable { get; set; }

		bool IsOccurenceTimeEnable { get; set; }

		bool IsPrefixEnable { get; set; }

		bool IsTraceEnable { get; set; }

		LogLevel Level { get; set; }
	}
}