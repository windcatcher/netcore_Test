using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Data
{
    public static class IWebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    //logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");
                    //var retry = Policy.Handle<SqlException>()
                    //     .WaitAndRetry(new TimeSpan[]
                    //     {
                    //         TimeSpan.FromSeconds(5),
                    //         TimeSpan.FromSeconds(10),
                    //         TimeSpan.FromSeconds(15),
                    //     });

                    //retry.Execute(() =>
                    //{
                    //    context.Database.Migrate();
                    //    //seeder(context, services);
                    //});
                    context.Database.Migrate();
                    //seeder(context, services);
                    logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                }
            }

            return webHost;
        }
    }

    public class ApplicationDbContextSeed
    {
        public async Task SeedAsync(ApplicationDbContextSeed context)
        {
       
            //if (!context.Brand.Any())
            //{
            //    context.Brand.AddRange(GetPreconfiguredBrands());
            //    await context.SaveChangesAsync();
            //}
      
        }

        //private IEnumerable<Brand> GetPreconfiguredBrands()
        //{
        //    return new List<Brand>()
        //    {
        //        new Brand(){Name="依琦莲",ImgUrl="upload/20141201101326051272.jpg",Sort=99,IsDisplay=1},
        //        new Brand(){Name="凯速",IsDisplay=1},
        //        new Brand(){Name="伊朵莲",IsDisplay=1},
        //        new Brand(){Name="菩媞",IsDisplay=1},
        //        new Brand(){Name="丹璐斯",IsDisplay=1},
        //        new Brand(){Name="喜悦瑜伽",IsDisplay=1},
        //    };
        //}



    }
}