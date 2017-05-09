using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgrammingInterceptorDemo
{
    public class TestClass: ITestClass
    {
        public void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }

        public void AnotherMethod()
        {
            Console.WriteLine("AnotherMethod");
        }
    }
}
