using ApiProductService.Infrastructure.Services;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Aop
{
    public class MemcacheDoBeforeAttribute : AbstractInterceptorAttribute
    {
        //时间 缓存时间
        public static int TIMEOUT = 360000;//秒
        private int expiry = TIMEOUT;
        [FromContainer]
        public ICachingProvider CachingProvider { get; set; }


        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            String cacheKey = null;
            var logger = context.ServiceProvider.GetRequiredService<ILogger<MemcacheDoBeforeAttribute>>();
            try
            {
                //去Memcached中看看有没有我们的数据  命名空间+ 类名 + 方法名 + 参数(多个)
                cacheKey = getCacheKey(context);
                logger.LogInformation($"cacheKey:{cacheKey}");

                var returnType = context.ServiceMethod.ReturnType;
                //如果Memcached 连接不上呢
                if (!CachingProvider.IsConnect)
                {
                    logger.LogError("Memcached服务器可能不存在或是连接不上");
                    await next(context);
                    return;
                }

                var cacheValue = CachingProvider.GetStringAsync(cacheKey).Result;
                //返回值
                if (string.IsNullOrEmpty(cacheValue))
                {
                    //回Service
                    await next(context);
                    var values = JsonConvert.SerializeObject(context.ReturnValue);
                    //先放到Memcached中一份
                    await CachingProvider.SetStringAsync(cacheKey, values, TimeSpan.FromSeconds(expiry));
                    cacheValue = values;
                }
                Console.WriteLine("Before service call");
                var value = JsonConvert.DeserializeObject(cacheValue, returnType);

                context.ReturnValue = value;
            }
            catch (Exception)
            {
            }
            finally
            {

            }
        }

        //命名空间+ 类名 + 方法名 + 参数(多个)  生成Key
        public String getCacheKey(AspectContext context)
        {
            //StringBuiter
            StringBuilder key = new StringBuilder();
            String packageName = context.ServiceMethod.DeclaringType.FullName;
            key.Append(packageName);
            // 方法名
            String methodName = context.ServiceMethod.Name;
            key.Append(".").Append(methodName);


            //参数(多个)
            var paramList = context.ServiceMethod.GetParameters();
            int index = 0;
            foreach (var param in paramList)
            {
                var value = param.ToString();

                key.Append("|").Append(param.Name);
                key.Append("_").Append(context.Parameters[index]);
                index++;
            }
            return key.ToString();
        }


        public void setExpiry(int expiry)
        {
            this.expiry = expiry;
        }


    }
}
