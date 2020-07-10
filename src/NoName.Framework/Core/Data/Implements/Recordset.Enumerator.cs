using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using NoName.Framework.Core.Data.Declarations;

namespace NoName.Framework.Core.Data.Implements
{
	public partial class Recordset
	{
		private class RecordsetEnumerator : IEnumerator<IRecordsetRow>
		{
			private int _currentPosition;

			public RecordsetEnumerator()
			{
				_currentPosition = 0;
			}

			public bool MoveNext()
			{
				throw new NotImplementedException();
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}

			public IRecordsetRow Current { get; }

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				throw new NotImplementedException();
			}
		}
	}
}
