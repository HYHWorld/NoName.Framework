namespace NoName.Framework.Core.Data
{
    public interface IRecordRow
    {
		object this[string key] { get; }
    }
}
