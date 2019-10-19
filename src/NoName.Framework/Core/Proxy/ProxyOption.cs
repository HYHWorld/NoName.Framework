using System;
using System.Collections.Generic;
using System.Reflection;

namespace NoName.Framework.Core.Proxy
{
    public class ProxyOption
    {
        public ProxyOption()
        {
            Wrappers = new List<ProxyWrapper>();
        }

        public IList<ProxyWrapper> Wrappers { get; }

        public void AddWrapper(
            Type targetType,
            MethodInfo methodInfo,
            Action<ProxyAdditionalActionParameter> additionalAction,
            ProxyIntent intent
            )
        {
            //判断MethodInfo是否是type的
            if (methodInfo.ReflectedType != targetType)
                throw new MethodAccessException("Method's type does not equal given type.");

            Wrappers.Add(
                         new ProxyWrapper
                         {
                             TargetType = targetType,
                             Intent = intent,
                             MethodInfo = methodInfo,
                             AdditionalAction = additionalAction
                         }
                        );
        }
    }
}