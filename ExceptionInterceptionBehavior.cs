using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgrammingInterceptorDemo
{
    public class ExceptionInterceptionBehavior : IInterceptionBehavior
    {
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var result = getNext()(input, getNext);
            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                var className = input.MethodBase.DeclaringType.IsInterface ? input.Target.GetType().Name : input.MethodBase.DeclaringType.Name;
                Console.WriteLine(String.Format(
                  "Method {0}::{1}() threw exception {2} at {3}",
                  className, input.MethodBase, result.Exception.Message,
                  DateTime.Now.ToLongTimeString()));
            }
            return result;
        }
    }
}
