using NoName.Framework.Core.Data.DataStore.Cache;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NoName.Framework.Core.Util.Module
{

    //创建动态Assembly 
    public class AssemblyScope
    {
        // Name
        private readonly string DefaultAssemblyName = "ProxyAssembly";

        //Type 缓存
        private ICache _cache;
        private string _assemblyName;
        private bool _saveAssembly;

        public AssemblyScope() : this(false)
        {

        }

        public AssemblyScope(bool saveAssembly)
        {
            _cache = new DefaultCache();
            _saveAssembly = saveAssembly;
        }

        public AssemblyBuilder CreateAssembly()
        {
            return CreateAssembly(_assemblyName);
        }

        public AssemblyBuilder CreateAssembly(string assemblyName)
        {
            var assembly = _cache[assemblyName] as AssemblyBuilder;
            if (assembly is null)
            {
                if (_saveAssembly)
                {
                    try
                    {



#if FEATURE_APPDOMAIN
                        return AppDomain.CurrentDomain.DefineDynamicAssembly(GetAssemblyName(assemblyName),
                            AssemblyBuilderAccess.RunAndSave);
#else
                        return AssemblyBuilder.DefineDynamicAssembly(GetAssemblyName(assemblyName), AssemblyBuilderAccess.Run);
#endif
                    }
                    catch (ArgumentException)
                    {

                    }
                }
                else
                {

                }

                return;
            }
        }

        private AssemblyName GetAssemblyName(string assamblyName)
        {
            return new AssemblyName(assamblyName);
        }
    }
}
