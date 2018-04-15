using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebHostBuild_Run
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
        public static IWebHostBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostContext, config) => {
                    //增加默认配置
                    var env = hostContext.HostingEnvironment;
                    config.AddJsonFile("appsetting.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsetting.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    if (env.IsDevelopment()) { }
                    config.AddEnvironmentVariables();
                    if (args != null)
                        config.AddCommandLine(args);

                })
                .ConfigureLogging((hostContext, config) => {
                    config.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    config.AddConsole();
                    config.AddDebug();
                })
                .UseIISIntegration();
            return builder;
        }

        // public static IWebHost BuildWebHost(string[] args) =>
        //     WebHost.CreateDefaultBuilder(args)
        //         .UseStartup<Startup>()
        //         .Build();
    }
}
