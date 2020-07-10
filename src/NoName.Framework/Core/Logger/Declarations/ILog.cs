using System;
using System.Diagnostics;

namespace NoName.Framework.Core.Logger.Declarations
{
	/// <summary>
	///     This is the interface for normal log record.
	///     Please extern it if you want to define any new style of log.
	/// </summary>
	public interface ILog
	{
		ILogAdditionalData AdditionalData { get; set; }

		string FormattedTrace { get; set; }

		string Message { get; set; }

		string MessagePrefix { get; set; }

		DateTime OccurrenceTime { get; set; }

		bool ReDisplay { get; set; }

		string SubMessage { get; set; }

		int ThreadId { get; set; }

		StackTrace Trace { get; set; }
	}
}