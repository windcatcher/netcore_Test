using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiOderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
               .MigrateDbContext<OrderContext>((context, services) =>
               {
                   new OrderContextSeed()
                   .SeedAsync(context)
                   .Wait();
               })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
