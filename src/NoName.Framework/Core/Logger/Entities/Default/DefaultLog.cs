using System;
using System.Diagnostics;

using NoName.Framework.Core.Logger.Declarations;

namespace NoName.Framework.Core.Logger.Entities.Default
{
	/// <summary>
	///     This is the default log style and just implement the method in ILog.
	///     In normal condition, we use this kind of Log.
	/// </summary>
	public class DefaultLog : ILog
	{
		public ILogAdditionalData AdditionalData { get; set; }

		public string FormattedTrace { get; set; }

		public string Message { get; set; }

		public string MessagePrefix { get; set; }

		public DateTime OccurrenceTime { get; set; }

		public bool ReDisplay { get; set; }

		public string SubMessage { get; set; }

		public int ThreadId { get; set; }

		public StackTrace Trace { get; set; }
	}
}