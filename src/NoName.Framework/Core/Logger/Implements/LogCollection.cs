using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using NoName.Framework.Core.Logger.Declarations;
using NoName.Framework.Core.Logger.Entities;

namespace NoName.Framework.Core.Logger.Implements
{
	public class LogCollection : IEnumerable<ILog>
	{
		private readonly int _currentIndex;

		private readonly List<ILog> _items;

		private readonly ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

		public LogCollection()
		{
			this._items = new List<ILog>();
			this.CollectionLogLevel = LogLevel.Info;
			this._currentIndex = 0;
		}

		public LogCollection(List<ILog> items)
			: this()
		{
			this._items.AddRange(items);
		}

		public LogCollection(List<ILog> items, LogLevel logLevel)
			: this(items)
		{
			this.CollectionLogLevel = logLevel;
		}

		public LogCollection(LogLevel logLevel)
			: this()
		{
			this.CollectionLogLevel = logLevel;
		}

		public LogLevel CollectionLogLevel { get; }

		public int Count
		{
			get
			{
				this._readerWriterLock.EnterReadLock();

				try
				{
					return this._items.Count;
				}
				finally
				{
					this._readerWriterLock.ExitReadLock();
				}
			}
		}

		public ILog this[int index]
		{
			get
			{
				this._readerWriterLock.EnterReadLock();

				try
				{
					return this._items[index];
				}
				finally
				{
					this._readerWriterLock.ExitReadLock();
				}
			}
		}

		public void AddLog(ILog log)
		{
			this._readerWriterLock.EnterWriteLock();

			try
			{
				this._items.Add(log);
			}
			finally
			{
				this._readerWriterLock.ExitWriteLock();
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
			this._readerWriterLock.EnterWriteLock();

			try
			{
				this._items.AddRange(logs);
			}
			finally
			{
				this._readerWriterLock.ExitWriteLock();
			}
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<ILog> GetEnumerator()
		{
			this._readerWriterLock.EnterReadLock();

			try
			{
				if (this._currentIndex > this._items.Count)
					yield break;
			}
			finally
			{
				this._readerWriterLock.ExitReadLock();
			}

			this._readerWriterLock.EnterUpgradeableReadLock();

			try
			{
				var res = this._items.Where(x => this._items.IndexOf(x) >= this._currentIndex).GetEnumerator();

				while (res.MoveNext())
					yield return res.Current;

				res.Dispose();
			}
			finally
			{
				this._readerWriterLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>
		///     An <see cref="System.Collections.IEnumerator"></see> object that can be used to iterate through the
		///     collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}