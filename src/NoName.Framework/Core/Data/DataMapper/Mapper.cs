using System;
using System.Collections.Generic;

namespace NoName.Framework.Core.Data.DataMapper
{
    public class Mapper<T> : IMapper<T>
    {
        public IEnumerable<Action<T>> Roles { get; }
    }
}