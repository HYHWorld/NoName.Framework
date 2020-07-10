using NoName.Framework.Core.Attributes;

namespace NoName.Framework.Core.Logger.Entities
{
	public enum LogLevel
	{
		/// <summary>
		///     Logging will be off
		/// </summary>
		[NormalExtraInfo(ExtraInfo = "Off")]
		Off = 0,

		/// <summary>
		///     Fatal logging level
		/// </summary>
		[NormalExtraInfo(ExtraInfo = "Fatal")]
		Fatal = 1,

		/// <summary>
		///     Error logging level
		/// </summary>
		[NormalExtraInfo(ExtraInfo = "Error")]
		Error = 2,

		/// <summary>
		///     Warn logging level
		/// </summary>
		[NormalExtraInfo(ExtraInfo = "Warn")]
		Warn = 3,

		/// <summary>
		///     Info logging level
		/// </summary>
		[NormalExtraInfo(ExtraInfo = "Info")]
		Info = 4,

		/// <summary>
		///     Debug logging level
		/// </summary>
		[NormalExtraInfo(ExtraInfo = "Debug")]
		Debug = 5,

		/// <summary>
		///     Trace logging level
		/// </summary>
		[NormalExtraInfo(ExtraInfo = "Trace")]
		Trace = 6
	}
}