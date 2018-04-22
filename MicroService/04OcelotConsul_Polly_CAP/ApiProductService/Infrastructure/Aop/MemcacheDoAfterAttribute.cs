using ApiProductService.Infrastructure.Services;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Aop
{
    public class MemcacheDoAfterAttribute : AbstractInterceptorAttribute
    {
        //CachingProvider
        [FromContainer]
        public ICachingProvider CachingProvider { get; set; }
        //public MemcacheDoAfterAttribute(ICachingProvider cache)
        //{
        //    CachingProvider = cache;
        //}

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var logger = context.ServiceProvider.GetRequiredService<ILogger<MemcacheDoAfterAttribute>>();
            try
            {

                await next(context);
            }
            catch (Exception)
            {
                Console.WriteLine("Service threw an exception!");
            }
            finally
            {

                //包名+ 类名 + 方法名 + 参数(多个)  生成Key
                //包名+ 类名 
                String packageName = context.ServiceMethod.DeclaringType.FullName;
                //add*  update* delete*  
                //包名+ 类名  开始的 都清理
                var keySet = CachingProvider.GetKeys();
                foreach (var key in keySet)
                {
                    if (key.StartsWith(packageName))
                        await CachingProvider.DeleteAsync(key);
                }
                Console.WriteLine("After service call");
            }
        }


    }
}
