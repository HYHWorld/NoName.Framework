using System;
using System.Reflection;
using System.Reflection.Emit;

using NoName.Framework.Core.Data.Declarations.DataStore.Cache;
using NoName.Framework.Core.Data.Implements.DataStore.Cache;

namespace NoName.Framework.Core.Util.Module
{
	// 创建动态Assembly 
	public class AssemblyScope
	{
		// Name
		private static readonly string DefaultAssemblyName = "ProxyAssembly";

		private string _assemblyName;

		// Type 缓存
		private ICache _cache;

		private bool _saveAssembly;

		public AssemblyScope()
			: this(false)
		{
		}

		public AssemblyScope(bool saveAssembly)
		{
			this._cache = new DefaultCache();
			this._saveAssembly = saveAssembly;
		}

		public AssemblyBuilder CreateAssembly()
		{
			return this.CreateAssembly(this._assemblyName);
		}

		public AssemblyBuilder CreateAssembly(string assemblyName)
		{
			var assembly = this._cache[assemblyName] as AssemblyBuilder;
			if (assembly is null)
			{
				if (this._saveAssembly)
				{
					try
					{
#if FEATURE_APPDOMAIN
                        return AppDomain.CurrentDomain.DefineDynamicAssembly(GetAssemblyName(assemblyName),
                            AssemblyBuilderAccess.RunAndSave);
#else
						return AssemblyBuilder.DefineDynamicAssembly(this.GetAssemblyName(assemblyName), AssemblyBuilderAccess.Run);
#endif
					}
					catch (ArgumentException)
					{
					}
				}
				else
				{
				}

				return null;
			}

			return null;
		}

		private AssemblyName GetAssemblyName(string assamblyName)
		{
			return new AssemblyName(assamblyName);
		}
	}
}