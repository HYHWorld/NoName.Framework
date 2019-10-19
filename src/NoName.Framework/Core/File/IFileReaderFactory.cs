namespace NoName.Framework.Core.File
{
    public interface IFileReaderFactory
    {
        IFileReader LoadFile(string fileName);

        IFileReader LoadFiles(string[] fileNames);
    }
}
