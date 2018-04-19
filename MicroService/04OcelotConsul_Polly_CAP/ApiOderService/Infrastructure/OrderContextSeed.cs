using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOderService
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
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    var retry = Policy.Handle<SqlException>()
                         .WaitAndRetry(new TimeSpan[]
                         {
                             TimeSpan.FromSeconds(5),
                             TimeSpan.FromSeconds(10),
                             TimeSpan.FromSeconds(15),
                         });

                    retry.Execute(() =>
                    {
                        context.Database.Migrate();
                        seeder(context, services);
                    });

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

    public class OrderContextSeed
    {
        public async Task SeedAsync(OrderContext context)
        {
            if (!context.Order.Any())
            {
                context.Order.AddRange(GetPreconfiguredOrders());
                await context.SaveChangesAsync();
            }
            if (!context.OrderItem.Any())
            {
                context.OrderItem.AddRange(GetPreconfiguredDetails());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<OrderItem> GetPreconfiguredDetails()
        {
            return new List<OrderItem>()
            {

            };
        }

        private IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order(){ Id=1,BuyerId=1,Oid="1",DeliverFee=10,PayableFee=0,TotalPrice=90,PaymentWay=1
                ,PaymentCash=1,Delivery=1,IsConfirm=1,IsPaiy=1,State=1,Note=""},
            };
        }
    }
}