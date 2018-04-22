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

namespace ApiProductService
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
                        //seeder(context, services);
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

    public class ProductContextSeed
    {
        public async Task SeedAsync(ProductContext context)
        {
            if (!context.Color.Any())
            {
                context.Color.AddRange(GetPreconfiguredColors());
                await context.SaveChangesAsync();
            }
            if (!context.Brand.Any())
            {
                context.Brand.AddRange(GetPreconfiguredBrands());
                await context.SaveChangesAsync();
            }
            if (!context.Product.Any())
            {
                context.Product.AddRange(GetPreconfiguredProducts());
                await context.SaveChangesAsync();
            }
            if (!context.Color.Any())
            {
                context.Color.AddRange(GetPreconfiguredColors());
                await context.SaveChangesAsync();
            }
            if (!context.Feature.Any())
            {
                context.Feature.AddRange(GetPreconfiguredFeatures());
                await context.SaveChangesAsync();
            }
            if (!context.ProductImg.Any())
            {
                context.ProductImg.AddRange(GetPreconfiguredProductImgs());
                await context.SaveChangesAsync();
            }
            if (!context.ProductType.Any())
            {
                context.ProductType.AddRange(GetPreconfiguredProductTypes());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<Brand> GetPreconfiguredBrands()
        {
            return new List<Brand>()
            {
                new Brand(){Name="依琦莲",ImgUrl="upload/20141201101326051272.jpg",Sort=99,IsDisplay=1},
                new Brand(){Name="凯速",IsDisplay=1},
                new Brand(){Name="伊朵莲",IsDisplay=1},
                new Brand(){Name="菩媞",IsDisplay=1},
                new Brand(){Name="丹璐斯",IsDisplay=1},
                new Brand(){Name="喜悦瑜伽",IsDisplay=1},
            };
        }

        private IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product(){Id=1,No="20141028114308048",Name="产品1",Weight=1,IsNew=0,IsHot=1,IsCommend=0
                    ,CreateTime =null,CreateUserId=null,CheckTime=null,CheckUserId=null,IsShow=1,IsDel=1,TypeId=2
                    ,BrandId=1,Keywords="",Sales=10,Description="",PackageList="衣服 裤子",Feature="1,2,3,4",Color="1,2,3,4,5",Size="S,M,L,XL" },
                  new Product(){Id=2,No="20141028114308048",Name="产品2",Weight=1,IsNew=0,IsHot=1,IsCommend=0
                    ,CreateTime =null,CreateUserId=null,CheckTime=null,CheckUserId=null,IsShow=1,IsDel=1,TypeId=2
                    ,BrandId=1,Keywords="",Sales=10,Description="",PackageList="衣服 裤子",Feature="1,2,3,4",Color="1,2,3,4,5",Size="S,M,L,XL" },
            };
        }
        private IEnumerable<Color> GetPreconfiguredColors()
        {
            return new List<Color>()
            {
                new Color(){ Id=1,Name="红色系",ParentId=0,ImgUrl="365756"},
                new Color(){ Id=2,Name="绿色系",ParentId=0,ImgUrl="365756"},
                new Color(){ Id=3,Name="蓝色系",ParentId=0,ImgUrl="365756"},
                new Color(){ Id=4,Name="黑色系",ParentId=0,ImgUrl="365756"},
                new Color(){ Id=5,Name="粉色系",ParentId=0,ImgUrl="714774"},
            };
        }
        private IEnumerable<Feature> GetPreconfiguredFeatures()
        {
            return new List<Feature>()
            {
            };
        }

        private IEnumerable<ProductImg> GetPreconfiguredProductImgs()
        {
            return new List<ProductImg>()
            {
            };
        }

        private IEnumerable<ProductType> GetPreconfiguredProductTypes()
        {
            return new List<ProductType>()
            {
            };
        }

        private IEnumerable<Sku> GetPreconfiguredSkus()
        {
            return new List<Sku>()
            {
            };
        }


    }
}