using System;
using System.IO;

using NoName.Framework.Core.Stream.Declarations;

namespace NoName.Framework.Core.File.Declarations
{
	public interface IFileReader
	{
		/// <summary>
		/// 在Using中使用这个函数
		/// </summary>
		/// <returns>文件暂存的内存流(未关闭)</returns>
		MemoryStream Read();

		T Read<T>(Func<MemoryStream, T> process);

		TR Read<TP, TR>(TP processor)
			where TP : IStreamProcessor<MemoryStream, TR>;
	}
}