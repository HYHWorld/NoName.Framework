using System;
using System.Reflection;

namespace NoName.Framework.Core.Proxy
{
    public class ProxyWrapper
    {
        public Action<ProxyAdditionalActionParameter> AdditionalAction { get; set; }

        public ProxyIntent Intent { get; set; }

        public MethodInfo MethodInfo { get; set; }

        public Type TargetType { get; set; }
    }
}