namespace NoName.Framework.Core.ConstData.Config
{
	public class ConfigConstData
	{
		/// <summary>
		/// 配置链接文件统一路径:
		///		将会优先使用系统环境中定义的配置链接文件路径
		/// </summary>
		public const string ConfigLinkingPath = "Config/root.clxml";

		/// <summary>
		/// 系统环境中配置链接文件路径变量名
		/// </summary>
		public const string ConfigLinkingPathSystemEnvironmentName = "NF_CONFIGLINKINGPATCH";

		/// <summary>
		/// 配置文件统一路径:
		///		将会优先使用系统环境中定义的配置文件路径
		/// </summary>
		public const string ConfigPath = "Config";

		/// <summary>
		/// 系统环境中配置文件路径变量名
		/// </summary>
		public const string ConfigPathSystemEnvironmentName = "NF_CONFIGPATCH";

		/// <summary>
		/// 配置文件系统的日志文件生成方案
		/// </summary>
		public const string ConfigSystemLogWriter = "SysConsoleLogWriter";
	}
}