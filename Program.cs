using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgrammingInterceptorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();
            unityContainer.AddNewExtension<Interception>();

            #region Using interception

            //Console.WriteLine("Using interface interception starts....");

            //unityContainer.RegisterType<ITestClass, TestClass>(
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<LoggingInterceptionBehavior>());
            //var testClass = unityContainer.Resolve<ITestClass>();
            //testClass.DoSomething();

            //unityContainer.RegisterType<ITestClass, SomeClass>("SomeClass",
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<LoggingInterceptionBehavior>());
            //var someClass = unityContainer.Resolve<ITestClass>("SomeClass");
            ////Below line doesn't record entry and exit of AnotherMethod() that gets called within DoSomething()
            //someClass.DoSomething();
            ////Explicitly calling Another() records entry and exit point
            //someClass.AnotherMethod();

            #endregion

            #region Using virtual methods

            Console.WriteLine("Using virtual method interception starts....");
            unityContainer.RegisterType<AnotherClass>(
                new Interceptor<VirtualMethodInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<ExceptionInterceptionBehavior>());
            var anotherClass = unityContainer.Resolve<AnotherClass>();
            //Below line - if we call DoSomething() which internally calls AnotherMethod(), entry and exit for both methods get recorded
            //Only criteria is we should declare both methods as public virtual
            anotherClass.DoSomething();

            //Test exception
            try
            {
                anotherClass.TestException();
            }
            catch (Exception ex)
            {

            }
            #endregion

            Console.ReadLine();
        }
    }
}
