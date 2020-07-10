using System.Collections.Generic;
using System.Text;

using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Entities.Default
{
	public class DefaultMessageFormatStrategy : IMessageFormatStrategy
	{
		public string FormatMessage(ILog log, INewLineStrategy newLineStrategy)
		{
			var param = new List<string>();
			var builder = new StringBuilder();

			if (log.AdditionalData.IsPrefixEnable)
			{
				builder.Append(log.MessagePrefix);
				builder.Append(":");
			}

			if (log.AdditionalData.IsLevelEnable)
			{
				builder.Append("[" + log.AdditionalData.Level + "]");
				builder.Append(":");
			}

			builder.Append(log.Message);

			if (!string.IsNullOrEmpty(log.SubMessage)) builder.Append($"({log.SubMessage})");

			if (log.AdditionalData.IsOccurenceTimeEnable) builder.Append($"[{log.OccurrenceTime:yyyy-mm-dd hh:mm:ss}]");

			if (log.AdditionalData.IsTraceEnable)
			{
				builder.Append(newLineStrategy.NewLine);
				builder.Append(log.FormattedTrace);
			}

			return builder.ToString();
		}
	}
}