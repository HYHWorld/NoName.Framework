using NoName.Framework.Core.Stream.Declarations.MemoryStream.Text;

namespace NoName.Framework.Core.Config.Declarations.Processors
{
	public interface IConfigTextMemoryStreamProcessor<out TC, out TO> : ITextMemoryStreamProcessor<TO>
		where TO : IConfig where TC : IConfigBuilder<TO>
	{
		TC CreateConfigBuilder();
	}
}