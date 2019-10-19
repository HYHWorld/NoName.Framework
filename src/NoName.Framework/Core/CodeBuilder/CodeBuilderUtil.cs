using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NoName.Framework.Core.CodeBuilder
{
    public class CodeBuilderUtil
    {
        private const string weakAssemblyName = "NoName.Freamwork.ExtraAssembly";
        private AssemblyBuilder _assemblyBuilder;


        public AssemblyBuilder GetUniqueExtraAssembly()
        {
            var assemblyName = GetSysAssemblyName();
            _assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        }

        public bool CheckTypeWithEvent(Type type, string eventName)
        {
            return !(type.GetEvent(
                                 eventName,
                                 BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase
                                ) is null);
        }

        private AssemblyName GetSysAssemblyName()
        {
            return new AssemblyName(weakAssemblyName);
        }
    }
}
