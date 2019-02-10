using System;
using System.Diagnostics;
using System.Text;

using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.DefaultSettings
{
	/// <summary>
	///     This is the default log style and just implement the method in ILog.
	///     In normal condition, we use this kind of Log.
	/// </summary>
	public class DefaultLog : ILog
	{

		public Boolean ReDisplay { get; set; }

		public String Message { get; set; }

		public String SubMessage { get; set; }

		public StackTrace Trace { get; set; }

		public String FormattedTrace { get; set; }

		public DateTime OccurrenceTime { get; set; }

		public Boolean IsTraceEnable { get; set; }

		public Boolean IsOccurenceTimeEnable { get; set; }

		public Int32 ThreadId { get; set; }

		public String FallMassage { get; set; }

		public LogLevel LogLevel { get; set; }
	}
}
