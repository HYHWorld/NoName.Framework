using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

using NoName.Framework.Core.Data.Declarations;
using NoName.Framework.Core.Inerfaces;

namespace NoName.Framework.Core.Data.Implements.Factory
{
	public class SetWrapperFactory : IFactory<ISetWrapper>
	{
		// 暂时设置成DataSetWrapper
		public Type DefalutProduct { get; } = typeof(DataSetWrapper);

		public ISetWrapper Produce()
		{
			return Produce(null);
		}

		public ISetWrapper Produce<TI>()
			where TI : class, ISetWrapper
		{
			return Produce<TI>(null);
		}

		public ISetWrapper Produce(Func<IFactoryProduceParameter> getFactoryProduceParameterFunction)
		{
			var parameter = getFactoryProduceParameterFunction?.Invoke() ?? new SetWrapperFactoryProduceParameter();

			return Activator.CreateInstance(
				       DefalutProduct,
				       BindingFlags.CreateInstance | BindingFlags.NonPublic,
				       null,
				       MapParameterDictionaryToObjectArray(parameter?.Parameters, DefalutProduct),
				       CultureInfo.CurrentUICulture) as ISetWrapper;
		}

		public ISetWrapper Produce<TI>(Func<IFactoryProduceParameter> getFactoryProduceParameterFunction)
			where TI : class, ISetWrapper
		{
			var parameter = getFactoryProduceParameterFunction?.Invoke() ?? new SetWrapperFactoryProduceParameter();

			return Activator.CreateInstance(
				       typeof(TI),
				       BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.Public,
				       null,
				       MapParameterDictionaryToObjectArray(parameter?.Parameters, typeof(TI)),
				       CultureInfo.CurrentUICulture) as ISetWrapper;
		}

		private object[] MapParameterDictionaryToObjectArray(Dictionary<string, object> parameterMapper, Type type)
		{
			var args = new ArrayList();
			var constructorInfos = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public);
			foreach (var constructorInfo in constructorInfos)
			{
				var parameters = constructorInfo.GetParameters();
				if (parameters.Length == parameterMapper.Count)
				{
					foreach (var parameter in parameters)
					{
						if (!parameter.IsOptional && !parameterMapper.ContainsKey(parameter.Name))
						{
							args.Clear();
							break;
						}

						args.Add(parameterMapper[parameter.Name]);
					}
				}
			}

			return args.ToArray();
		}
	}
}