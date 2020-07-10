using System;
using System.Collections.Generic;

using NoName.Framework.Core.Data.Declarations.DataStore.DataMapper;

namespace NoName.Framework.Core.Data.Implements.DataStore.DataMapper
{
    public class Mapper<T> : IMapper<T>
    {
        public IEnumerable<Action<T>> Roles { get; }
    }
}