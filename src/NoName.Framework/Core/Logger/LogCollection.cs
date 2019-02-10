using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NoName.Framework.Core.Logger
{
	public class LogCollection : IEnumerable<ILog>
	{
		private readonly Int32 _currentIndex;

		private readonly ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

		public LogCollection()
		{
			_items = new List<ILog>();
			CollectionLogLevel = LogLevel.Info;
			_currentIndex      = 0;
		}

		public LogCollection(List<ILog> items) : this()
		{
			_items.AddRange(items);
		}

		public LogCollection(List<ILog> items, LogLevel logLevel) : this(items)
		{
			CollectionLogLevel = logLevel;
		}

		public LogCollection(LogLevel logLevel) : this()
		{
			CollectionLogLevel = logLevel;
		}

		private readonly List<ILog> _items;

		public LogLevel CollectionLogLevel { get; }

		public ILog this[Int32 index]
		{
			get
			{
				_readerWriterLock.EnterReadLock();

				try
				{
					return _items[index];
				}
				finally
				{
					_readerWriterLock.ExitReadLock();
				}
			}
		}

		public Int32 Count
		{
			get
			{
				_readerWriterLock.EnterReadLock();

				try
				{
					return _items.Count;
				}
				finally
				{
					_readerWriterLock.ExitReadLock();
				}
			}
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<ILog> GetEnumerator()
		{
			_readerWriterLock.EnterReadLock();

			try
			{
				if (_currentIndex > _items.Count)
					yield break;
			}
			finally
			{
				_readerWriterLock.ExitReadLock();
			}

			_readerWriterLock.EnterUpgradeableReadLock();

			try
			{
				var res = _items.Where(x=> _items.IndexOf(x) >= _currentIndex)
				               .GetEnumerator();

				while (res.MoveNext())
					yield return res.Current;

				res.Dispose();
			}
			finally
			{
				_readerWriterLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>
		///     An <see cref="System.Collections.IEnumerator"></see> object that can be used to iterate through the
		///     collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void AddLog(ILog log)
		{
			_readerWriterLock.EnterWriteLock();

			try
			{
				_items.Add(log);
			}
			finally
			{
				_readerWriterLock.ExitWriteLock();
			}
		}

		/// <summary>
		///     Add new logs
		/// </summary>
		/// <remarks>
		///     If there has multiple logs from the same place in the code, please use this function to add them, it is more
		///     efficient.
		/// </remarks>
		/// <param name="logs"></param>
		public void AddLogs(IEnumerable<ILog> logs)
		{
			_readerWriterLock.EnterWriteLock();

			try
			{
				_items.AddRange(logs);
			}
			finally
			{
				_readerWriterLock.ExitWriteLock();
			}
		}
	}
}
