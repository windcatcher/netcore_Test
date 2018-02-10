using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEcom.Entity
{
    public class EcomContextSeed
    {
        public async Task SeedAsync(ecomContext context)
        {
            if (!context.BbsBuyer.Any())
            {
                context.BbsBuyer.AddRange(GetPreconfiguredBbsBuyers());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<BbsBuyer> GetPreconfiguredBbsBuyers()
        {
            return new List<BbsBuyer>()
            {
                new BbsBuyer(){Username="fbb2014",Password="e10adc3949ba59abbe56e057f20f883e",Email="112624349@qq.com",Gender="WOMAN",RealName="范冰冰",Province="120000",City="120100",Town="120105",Addr="海淀区建材城西路100号",IsDel=1},
            };
        }
    }

    public static class IWebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    //  logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    var retry = Policy.Handle<SqlException>()
                         .WaitAndRetry(new TimeSpan[]
                         {
                             TimeSpan.FromSeconds(5),
                             TimeSpan.FromSeconds(10),
                             TimeSpan.FromSeconds(15),
                         });

                    retry.Execute(() =>
                    {
                        //if the sql server container is not created on run docker compose this
                        //migration can't fail for network related exception. The retry options for DbContext only
                        //apply to transient exceptions.

                        context.Database.Migrate();
                        seeder(context, services);
                    });

                    //logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    //logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                }
            }

            return webHost;
        }
    }
}