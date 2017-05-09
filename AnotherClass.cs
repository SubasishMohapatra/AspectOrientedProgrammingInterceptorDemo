using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgrammingInterceptorDemo
{
    public class AnotherClass
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("DoSomething");
            AnotherMethod();
        }

        public virtual void AnotherMethod()
        {
            Console.WriteLine("AnotherMethod");
        }

        public virtual void TestException()
        {
            throw new NotImplementedException();
        }
    }
}
