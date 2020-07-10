using System;
using System.Collections.Generic;

using NoName.Framework.Core.Attributes;

namespace NoName.Framework.Engine.Service
{
	// Loader什么用
	// 当Service要上线时，判断当前系统所需的所有相关资源是否齐备，并初始化使用的资源
	// 当Service要下线时，Loader会释放所有占用的资源，并保存一些状态
	// 如果新建完Service对象，发现Service已经存在于系统，Loader 将把Service以某种规则，更新为新的Service，
	// 老旧Service将可通过特殊方式继续使用，直到Service下线
	// 如何判断老旧Service下线？？在不做特殊处理的情况下Service永久在线（即需要手动下线）
	// 如何区分不同的服务？？ 同一Service 版本不同，不同Service通过UniqueID区分
	// 顺序:Source File(script,dll...),Properties,Command->Loader->ServiceInstanceFactory->Service
	[ConfigItem(ConfigPath = ConfigItemAttribute.DefaultConfigPath, ConfigFileExtension = "cfg", ConfigName = "Services")]
	public interface IServiceLoader : ICloneable
	{
		IService CurrentService { get; }

		T CreateClient<T>()
			where T : IServiceClient;

		T CreateClient<T>(Func<IDictionary<string, string>> additionalOptions)
			where T : IServiceClient;

		IService GetRevision();

		IEnumerable<IService> GetRevisions();

		void Load();

		void Load(Func<IDictionary<string, string>> extraFunc);

		void Offline();

		void Online();
	}
}