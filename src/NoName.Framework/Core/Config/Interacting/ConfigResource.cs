using System;
using System.IO;

using NoName.Framework.Core.Attributes.Resource;
using NoName.Framework.Core.Config.Declarations;
using NoName.Framework.Core.Config.Implements;
using NoName.Framework.Core.ConstData.Config;
using NoName.Framework.Core.File.Implements;
using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Logger.Declarations.Console;
using NoName.Framework.Core.Logger.Implements.Default;
using NoName.Framework.Core.ObjectContainers.Declarations;
using NoName.Framework.Core.Resource.LocalResource;
using NoName.Framework.Core.SystemWrapper.Declarations;
using NoName.Framework.Core.SystemWrapper.Implements;

namespace NoName.Framework.Core.Config.Interacting
{
	public class ConfigResource : IResource, IManagedObject
	{
		private IConfigLoader _configLoader;

		public ConfigResource()
		{
			this.LogFactory = new DefaultLogFactory();
			this.SysEnvironment = new SysEnvironment();
			this._configLoader = new DefaultConfigLoader(new FileReaderFactory());
		}

		[AssignResource(ResourceName = ConfigConstData.ConfigSystemLogWriter, Type = typeof(ILogFactory))]
		private IConsoleLogWriter ConsoleLogWriter { get; set; }

		private ILogFactory LogFactory { get; set; }

		private ISysEnvironment SysEnvironment { get; set; }

		public void InitializeResource()
		{
			// 创建配置文件文件夹
			this.CreateConfigDirectory();

			// 创建配置链接文件
			this.CreateConfigLinkingFile();

			// 加载配置文件
			// 配置文件资源指定有两个途径:
			// 	1. 链接文件中指定
			// 	2. Attribute中指定
			foreach (var fileName in Directory.GetFiles(ConfigConstData.ConfigPath, "*.conf;*.clxml", SearchOption.AllDirectories))
			{
				this._configLoader.LoadConfig(fileName);
			}
		}

		public void OnConstructed() => throw new System.NotImplementedException();

		private void CreateConfigDirectory()
		{
			var configPath = this.GetConfigFilePath();

			if (!Directory.Exists(configPath))
			{
				try
				{
					Directory.CreateDirectory(configPath);
				}
				catch (UnauthorizedAccessException)
				{
					// TODO: You have no permission to create the Directory, you can retry it by following steps. 
					// 1.please check if this is admin user or normal user.
					// 2.please check if the full dictionary path name is valid(maybe too lang).
				}
			}
		}

		private void CreateConfigLinkingFile()
		{
			var configLinkingFile = this.GetConfigLinkingFilePath();
			if (!System.IO.File.Exists(configLinkingFile))
			{
				try
				{
					System.IO.File.Create(configLinkingFile);
				}
				catch (UnauthorizedAccessException)
				{
					// TODO: You have no permission to create the Directory, you can retry it by following steps. 
					// 1.please check if this is admin user or normal user.
					// 2.please check if the full dictionary path name is valid(maybe too lang).
				}
			}
		}

		private string GetConfigFilePath()
		{
			var sysConfigPath = this.SysEnvironment.GetValue(ConfigConstData.ConfigPathSystemEnvironmentName);

			return sysConfigPath ?? ConfigConstData.ConfigPath;
		}

		private string GetConfigLinkingFilePath()
		{
			var sysConfigLinkingPath = this.SysEnvironment.GetValue(ConfigConstData.ConfigLinkingPathSystemEnvironmentName);

			return sysConfigLinkingPath ?? ConfigConstData.ConfigLinkingPath;
		}
	}
}