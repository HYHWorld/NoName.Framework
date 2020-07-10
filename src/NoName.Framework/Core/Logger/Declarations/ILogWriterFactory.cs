using NoName.Framework.Core.Util;

namespace NoName.Framework.Core.Logger.Declarations
{
	public interface ILogWriterFactory<TW>
		where TW : class, ILogWriter
	{
		T CreateLogFactory<T>(INewLineStrategy newLineStrategy, ITraceFormatStrategy traceFormatStrategy, IMessageFormatStrategy messageFormatStrategy)
			where T : class, ILogFactory, new();

		ILogWriter CreateLogWriter(params object[] constructorParamList);
	}
}