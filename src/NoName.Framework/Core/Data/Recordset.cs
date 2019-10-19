using System.Collections.Generic;
using System.Linq;

namespace NoName.Framework.Core.Data
{
    /// <summary>
    ///     为 IList<T> 提供支持
    /// </summary>
    public class Recordset : IRecordset
    {
		public object this[string key]
		{
			get
			{
				return _rows[_currentRow][key];
			}
		}

		private int _currentRow { get; set; }

		private List<IRecordRow> _rows { get; set; }

		public IEnumerable<IRecordRow> Rows
		{
			get { return _rows; }
		}
    }
}