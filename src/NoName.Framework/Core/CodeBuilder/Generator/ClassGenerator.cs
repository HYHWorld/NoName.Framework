using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NoName.Framework.Core.CodeBuilder.Generator
{
	// build 出一个class
	public class ClassGenerator
	{
		private readonly ModuleBuilder _builder;

		private readonly string _className;

		private Type _baseType;

		private TypeBuilder _typeBuilder;

		// 需要什么Class,从什么东西里来
		public ClassGenerator(string className, ModuleBuilder builder)
			: this(className, builder, null)
		{
		}

		public ClassGenerator(string className, ModuleBuilder builder, Type baseType)
		{
			this._builder = builder;
			this._className = className;
			this._baseType = baseType;
		}

		public Type CreateClass()
		{
			this._typeBuilder = this._builder.DefineType(this._className);
			return this._typeBuilder;
		}

		private void GenerateConstructor(ConstructorInfo constructor)
		{
		}

		private void GenerateConstructors()
		{
			var flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			var baseConstructors = this._baseType.GetConstructors(flag);

			foreach (var constructor in baseConstructors)
			{
			}
		}
	}
}