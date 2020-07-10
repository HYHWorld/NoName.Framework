using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Declarations
{
	public interface IMessageFormatStrategy
	{
		string FormatMessage(ILog log, INewLineStrategy newLineStrategy);
	}
}