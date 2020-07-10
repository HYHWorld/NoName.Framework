namespace NoName.Framework.Core.Stream.Declarations
{
	public interface IMemoryStreamProcessor<out TO> : IStreamProcessor<System.IO.MemoryStream, TO>
	{
	}
}