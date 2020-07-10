using NoName.Framework.Core.Logger.Implements;
using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Declarations
{
	public interface ILogWriter
	{
		LogCollection Items { get; }

		IMessageFormatStrategy MessageFormatStrategy { get; set; }

		INewLineStrategy NewLineStrategy { get; set; }

		void AddLog(ILog log);

		void Close();

		void Write();
	}
}