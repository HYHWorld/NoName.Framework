using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName.Framework.Core.Attributes.Resource
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AssignResourceAttribute : Attribute
    {
        public Type Type { get; set; }

        public string ResourceName { get; set; }
    }
}
