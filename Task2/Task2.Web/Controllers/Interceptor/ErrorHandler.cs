using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Castle.Core.Interceptor;
using Microsoft.AspNetCore.Mvc;

namespace Task2.Web.Controllers.Interceptor
{
    public class ErrorHandler : IInterceptor
    {
        public readonly TextWriter Output;

        public ErrorHandler(TextWriter output)
        {
            Output = output;
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