namespace NoName.Framework.Core.Data.Declarations
{
	public interface IRecordsetRow : IFieldValueConverter
	{
		object this[string key] { get; set; }

		object this[int index] { get; set; }
	}
}