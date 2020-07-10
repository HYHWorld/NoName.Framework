using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NoName.Framework.Core.CodeBuilder
{
	public class CodeBuilderUtil
	{
		private const string WeakAssemblyName = "NoName.Freamwork.ExtraAssembly";

		private AssemblyBuilder _assemblyBuilder;

		public bool CheckTypeWithEvent(Type type, string eventName)
		{
			return !(type.GetEvent(eventName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase) is null);
		}

		public AssemblyBuilder GetUniqueExtraAssembly()
		{
			var assemblyName = this.GetSysAssemblyName();
			this._assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			return this._assemblyBuilder;
		}

		private AssemblyName GetSysAssemblyName()
		{
			return new AssemblyName(WeakAssemblyName);
		}
	}
}