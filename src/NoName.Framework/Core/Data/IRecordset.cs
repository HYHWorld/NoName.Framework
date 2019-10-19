using System.Collections.Generic;

namespace NoName.Framework.Core.Data
{
    public interface IRecordset
    {
        IEnumerable<IRecordRow> Rows { get; }
    }
}
