namespace NoName.Framework.Core.Config.Declarations
{
	public interface IConfigLoader
	{
		IConfig LoadConfig(string fileName);
	}
}