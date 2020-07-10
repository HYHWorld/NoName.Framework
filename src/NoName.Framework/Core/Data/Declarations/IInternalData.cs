namespace NoName.Framework.Core.Data.Declarations
{
	public interface IInternalData
	{
		string UserMessage { get; set; }

		object this[string key] { get; set; }
	}
}