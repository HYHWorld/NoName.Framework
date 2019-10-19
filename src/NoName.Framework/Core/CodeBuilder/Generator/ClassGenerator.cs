using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NoName.Framework.Core.CodeBuilder.Generator
{
    //build 出一个class
    public class ClassGenerator
    {
        private Type _baseType;
        private readonly ModuleBuilder _builder;

        private readonly string _className;
        private TypeBuilder _typeBuilder;

        //需要什么Class,从什么东西里来
        public ClassGenerator(string className, ModuleBuilder builder) : this(className, builder, null)
        {
        }

        public ClassGenerator(string className, ModuleBuilder builder, Type baseType)
        {
            _builder = builder;
            _className = className;
            _baseType = baseType;
        }

        public Type CreateClass()
        {
            _typeBuilder = _builder.DefineType(_className);
            return _typeBuilder;
        }

        private void GenerateConstructors()
        {
            var flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var
                baseConstructors =
                    _baseType.GetConstructors(flag);

            foreach (var constructor in baseConstructors)
            {


            }
        }

        private void GenerateConstructor(ConstructorInfo constructor)
        {

        }
    }
}