using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

using NoName.Framework.Core.Data.Declarations.DataStore.Cache;

namespace NoName.Framework.Core.Proxy
{
	public sealed class ProxyBuilder
	{
		private AssemblyBuilder _assemblyBuilder;

		private ICache _cache;

		public ProxyBuilder(ICache cache)
		{
			this._cache = cache;
#if FEATURE_APPDOMAIN
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                assemblyName, AssemblyBuilderAccess.Run);
#else
			var assemblyBuilder = this._assemblyBuilder;
#endif

			// _currentDomain = AppDomain.CurrentDomain;
		}

		// 函数调用前后做的事情
		// 对象创建前后做的事情
		// 创建出来的对象应该与原基类相同，
		// 对象的属性不应该在代理过程中有改动
		// 是否可继承，是否可创建对象

		// 可继承的类的Proxy
		public object Build(Type type, ProxyOption option)
		{
			// 判断类型的属性
			////是否可继承

			// 获取所有需要反射的类和其接口
			List<Type> list = new List<Type>();

			list.Add(type);
			list.AddRange(type.GetInterfaces());
			return null;
		}

		public Type Build<T, R>(object obj, MethodInfo[] methods, Action<T> before, Action<T> after)
		{
			return null;
		}

		public Type Build(ProxyOption option)
		{
			// ClassGenerator classGenerator = new ClassGenerator(baseType.Name,);

			// foreach (var item in option.Wrappers)
			// {
			// switch (item.Intent)
			// {
			// case ProxyIntent.AddBeforeAction:
			// _cache[""] as ModuleBuilder

			// item.TargetType

			// case ProxyIntent.AddAfterAction:
			// }
			// }
			return null;
		}

		public void Load(Assembly assembly)
		{
			this.RegisterFromAttribute(assembly);
			assembly.GetTypes();
		}

		public void RegisterFromAttribute(Assembly assembly)
		{
		}
	}
}