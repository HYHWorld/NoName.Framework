using NoName.Framework.Core.Logger.DefaultSettings;
using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.Logger
{
    public class ConsoleLogWriter : ILogWriter
    {
        public ConsoleLogWriter(ILogWriterFactory<ILogWriter> logWriterFactory)
        {
            Factory = logWriterFactory;
            Items = new LogCollection();
            DefaultLogFactory = Factory.CreateLogFactory<DefaultLogFactory>(new DefaultConsoleNewLineStrategy(), new DefaultTraceFormatStrategy());
        }

        public ILogFactory DefaultLogFactory { get; }

        public LogCollection Items { get; }

        public ILogWriterFactory<ILogWriter> Factory { get; }

        public void AddLog(ILog log)
        {
            Items.AddLog(log);
        }

        public void AddLogs(IEnumerable<ILog> logs)
        {
            Items.AddLogs(logs);
        }

        public void Write()
        {
            foreach (var item in Items) Console.Out.WriteAsync(item.FallMassage);
        }
    }
}