using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCore_Log
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             //.ConfigureLogging((hostContext, config) =>
             //{
             //    config.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
             //    config.AddConsole();
             //    config.AddDebug();
             //})
                .UseStartup<Startup>()
                .Build();
    }
}
