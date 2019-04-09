using System;
using Castle.DynamicProxy;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Task2.Infrastructure; //
using Task2.Web.Controllers.Interceptor; //


namespace Task2.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}