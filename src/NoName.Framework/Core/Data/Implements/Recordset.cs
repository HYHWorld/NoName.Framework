using System.Collections;
using System.Collections.Generic;

using NoName.Framework.Core.Data.Declarations;
using NoName.Framework.Core.Data.Entities;
using NoName.Framework.Core.Inerfaces;

namespace NoName.Framework.Core.Data.Implements
{
	/// <summary>
	///     为 IList 提供支持
	/// </summary>
	public partial class Recordset : IRecordset
	{
		private readonly ISetWrapper _wrapper;

		public IInternalData InternalData { get; }

		public object this[string key]
		{
			get => _wrapper[key];
			set => _wrapper[key] = value;
		}

		public void AddNew()
		{
			_wrapper.AddNew();
		}

		public void AddNewGroup()
		{
			_wrapper.AddNewGroup();
		}

		public IEnumerator<IRecordsetRow> GetEnumerator()
		{
			// Per-Condition : 
			// Data Set 
			throw new System.NotImplementedException();
		}

		public void Remove()
		{
			_wrapper.Remove();
		}

		public void RemoveGroup()
		{
			_wrapper.RemoveGroup();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}