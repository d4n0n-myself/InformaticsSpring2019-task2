using System;
using System.IO;
using Castle.Core.Interceptor;

namespace Task2.Infrastructure.Interceptor
{
    public class ErrorHandler : IInterceptor
    {
        public readonly TextWriter Output;

        public ErrorHandler()
        {
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Output.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}