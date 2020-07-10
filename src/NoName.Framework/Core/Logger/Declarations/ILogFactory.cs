using System;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Declarations
{
	public interface ILogFactory
	{
		IMessageFormatStrategy MessageFormatStrategy { get; set; }

		INewLineStrategy NewLineStrategy { get; set; }

		ITraceFormatStrategy TraceFormatStrategy { get; set; }

		T Create<T>(string message, ILogAdditionalData logAdditionalData)
			where T : class, ILog, new();
	}
}