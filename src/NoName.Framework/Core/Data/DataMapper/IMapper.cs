using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.Data.DataMapper
{
    public interface IMapper<T>
    {
        IEnumerable<Action<T>> Roles { get; }
    }
}
