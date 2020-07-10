using System;

using NoName.Framework.Core.SystemWrapper.Declarations;

namespace NoName.Framework.Core.SystemWrapper.Implements
{
	public class SysEnvironment : ISysEnvironment
	{
		// TODO: 需要添加Cahce, 或者添加不可重复获取异常
		public SysEnvironment()
		{
		}

		public string GetValue(string key)
		{
			return Environment.GetEnvironmentVariable(key);
		}
	}
}