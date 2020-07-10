namespace NoName.Framework.Core.Stream.Declarations
{
	public interface IStreamProcessor<in TR, out TO>
		where TR : System.IO.Stream
	{
		TO Process(TR stream);
	}
}