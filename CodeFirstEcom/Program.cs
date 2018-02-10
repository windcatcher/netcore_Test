using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstEcom.Entity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CodeFirstEcom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).MigrateDbContext<ecomContext>((context, services) =>
            {
                new EcomContextSeed()
                .SeedAsync(context)
                .Wait();

            }).Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args) .UseStartup<Startup>() .Build();


        public static void InitData()
        {

        }
    }

   
}
