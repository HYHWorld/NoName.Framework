using NoName.Framework.Core.Util;
using System;
using System.Collections;

namespace NoName.Framework.Core.Logger.DefaultSettings
{
    public class DefaultLogWriterFactory<TW> : ILogWriterFactory<TW> where TW : class, ILogWriter
    {
        public TW CreateLogWriter(params object[] constructorParamList)
        {
            var array = new ArrayList();
            if (constructorParamList != null) array.AddRange(constructorParamList);

            array.Add(this);
            return Activator.CreateInstance(typeof(StreamLogWriter), array.ToArray()) as TW;
        }

        public T CreateLogFactory<T>(INewLineStrategy newLineStrategy, ITraceFormatStrategy traceFormatStrategy)
            where T : class, ILogFactory, new()
        {
            return new T
            {
                NewLineStrategy = newLineStrategy,
                TraceFormatStrategy = traceFormatStrategy
            };
        }
    }
}