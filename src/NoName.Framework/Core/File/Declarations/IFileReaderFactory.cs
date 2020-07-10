namespace NoName.Framework.Core.File.Declarations
{
	public interface IFileReaderFactory
	{
		IFileReader LoadFile(string fileName);

		IFileReader LoadFiles(string[] fileNames);
	}
}