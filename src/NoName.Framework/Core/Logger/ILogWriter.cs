using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.Framework.Core.Logger
{
	public interface ILogWriter
	{
		ILogWriterFactory Factory { get; }

		LogCollection Items { get; }

		void AddLog(ILog log);

		void Write();
	}
}
