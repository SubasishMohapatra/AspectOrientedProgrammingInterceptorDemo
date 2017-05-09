using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgrammingInterceptorDemo
{
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var className = input.MethodBase.DeclaringType.IsInterface ? input.Target.GetType().Name : input.MethodBase.DeclaringType.Name;
            Console.WriteLine("Enter {0}::{1}()", className, input.MethodBase.Name);
            var result = getNext()(input, getNext);
            Console.WriteLine("Exit {0}::{1}()", className, input.MethodBase.Name);
            return result;
        }
    }
}
