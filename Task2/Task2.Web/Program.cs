using System;
using Castle.DynamicProxy;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Task2.Infrastructure; //

//


namespace Task2.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}