using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using NoName.Framework.Core.Data.Declarations;

namespace NoName.Framework.Core.Data.Implements
{
	public partial class DataSetWrapper : ISetWrapper, IRecordsetRow
	{
		private readonly DataSet _dataSet;

		private readonly IList<Field> _fields;

		private int _currentRow;

		private int _currentTable;

		private DataTable _table;

		public DataSetWrapper(DataSet dataSet)
		{
			_fields = new List<Field>();
			_dataSet = dataSet;
			_currentTable = -1;
			_currentRow = -1;
			Type = _dataSet.GetType();
		}

		public IList<Field> Fields
		{
			get
			{
				if (_fields.Any())
				{
					return _fields;
				}

				var index = 0;
				foreach (DataColumn column in _table.Columns)
				{
					_fields.Add(DataColumnToField(column, index++));
				}

				return _fields;
			}
		}

		public Type Type { get; }

		public object this[string key]
		{
			get => GetValueByColumnName(key);
			set => throw new NotImplementedException();
		}

		public object this[int index]
		{
			get => GetValueByIndex(index);
			set => throw new NotImplementedException();
		}

		public object GetValueByColumnName(string columnName)
		{
			var columns = _fields.Select(
				x =>
					{
						if (x.Name.Equals(columnName))
						{
							return x;
						}

						return null;
					}).Where(x => x != null).ToList();

			if (!columns.Any())
			{
				throw new System.Exception($"No column names {columnName}, Please re-check the columnName provided.");
			}

			if (columns.Count() > 1)
			{
				throw new System.Exception(
					$"There are multiple columns exist in this table with the same name {columnName}, can not specify which column should be used. Please provide the column index instead.");
			}

			return GetValueByIndex(columns.First().Index);
		}

		public object GetValueByIndex(int columnIndex)
		{
			if (columnIndex >= _table.Columns.Count)
			{ 
			}
			
			return _table.Rows[_currentRow][columnIndex];
		}

		public void AddNew()
		{
			_table.NewRow();
			_currentRow = _table.Rows.Count - 1;
		}

		public void AddNewGroup()
		{
			_dataSet.Tables.Add();
		}

		public void Remove()
		{
			_table.Rows.RemoveAt(_currentRow);
		}

		public void RemoveGroup()
		{
			_dataSet.Tables.RemoveAt(_currentTable);
		}

		public bool MoveNext()
		{
			if (_table.Rows.Count == _currentRow + 1)
			{
				return false;
			}

			_currentRow++;
			return true;
		}

		public bool MoveNextGroup()
		{
			if (_dataSet.Tables.Count == _currentTable + 1)
			{
				return false;
			}

			_table = _dataSet.Tables[++_currentTable];
			return true;
		}

		private Field DataColumnToField(DataColumn column, int index)
		{
			var field = new Field
				{
					Name = column.ColumnName,
					FieldType = column.DataType,
					Index = index,
					IsReadOnly = column.ReadOnly,
					IsAutoIncrement = column.AutoIncrement
				};

			return field;
		}
	}
}