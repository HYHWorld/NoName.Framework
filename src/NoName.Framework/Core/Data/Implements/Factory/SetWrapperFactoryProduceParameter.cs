using System;
using System.Collections.Generic;

using NoName.Framework.Core.Inerfaces;

namespace NoName.Framework.Core.Data.Implements.Factory
{
	public class SetWrapperFactoryProduceParameter : IFactoryProduceParameter
	{
		private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

		public object DataSource
		{
			get => this["DataSource"];
			set => this["DataSource"] = value;
		}

		public Dictionary<string, object> Parameters
		{
			get => _parameters;
		}

		public object this[string key]
		{
			get => GetParameterValue(key);
			set => SetParameterValue(key, value);
		}

		private object GetParameterValue(string key)
		{
			if (_parameters.ContainsKey(key))
			{
				return _parameters[key];
			}

			return null;
		}

		private void SetParameterValue(string key, object value)
		{
			if (string.IsNullOrEmpty(key))
			{
				// TODO: Exception
				throw new ArgumentException("SetWrapperFactoryParameter key value chould not be null or empty");
			}

			if (_parameters.ContainsKey(key))
			{
				_parameters[key] = value;
			}

			_parameters.Add(key, value);
		}
	}
}