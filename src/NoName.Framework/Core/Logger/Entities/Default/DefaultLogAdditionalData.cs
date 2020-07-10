using NoName.Framework.Core.Logger.Declarations;

namespace NoName.Framework.Core.Logger.Entities.Default
{
	public class DefaultLogAdditionalData : ILogAdditionalData
	{
		public bool IsLevelEnable { get; set; }

		public bool IsOccurenceTimeEnable { get; set; }

		public bool IsPrefixEnable { get; set; }

		public bool IsTraceEnable { get; set; }

		public LogLevel Level { get; set; } = LogLevel.Info;
	}
}