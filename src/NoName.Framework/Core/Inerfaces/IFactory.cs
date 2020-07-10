using System;

namespace NoName.Framework.Core.Inerfaces
{
	public interface IFactory<T>
	{
		Type DefalutProduct { get; }

		T Produce();

		T Produce<TI>() where TI : class, T;

		T Produce(Func<IFactoryProduceParameter> getParameter);

		T Produce<TI>(Func<IFactoryProduceParameter> getParameter)
			where TI : class, T;
	}
}