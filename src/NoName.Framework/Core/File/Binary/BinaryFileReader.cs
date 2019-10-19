using System.Collections.Generic;
using NoName.Framework.Core.Logger;
using NoName.Framework.Core.Logger.DefaultSettings;
using NoName.Framework.Core.Resource;
using System.IO;
using System.Linq;

namespace NoName.Framework.Core.File.Binary
{
    public class BinaryFileReader : IFileReader
    {
	    private const int BufferLen = 1024;

        private readonly BinaryReader reader;
        private readonly ILogWriter logWriter;

        public BinaryFileReader(string fileName)
        {
            reader = new BinaryReader(new FileStream(fileName, FileMode.Open));
            logWriter = ResourceLocator.Instance.SharedResource.Resolve<LoggerSharedResource>().LocalLog;
        }

        public object Read()
        {
			var buffer = new byte[1024];
			var result = new List<byte>();
			var len = 0;
			var outputStream = new MemoryStream();
			var writer = new BinaryWriter(outputStream);
			while ((len = reader.Read(buffer,len, BufferLen)) != 0)
			{
				writer.Write();
				writer.Write();
				
			}
            try
            {
                var result = (object)buffer.ToArray();
                return result;
            }
            catch (System.Exception e)
            {
                logWriter.AddLog(logWriter.DefaultLogFactory.Create<DefaultLog>(e.Message, true, LogLevel.Error));
            }
            finally
            {
                reader.Close();
            }

            return default;
        }
    }
}