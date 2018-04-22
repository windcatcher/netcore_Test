using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Polly;
using Resilience.Http;

namespace MvcClient.Infrastructure
{
    public class ResilientHttpClientFactory : IResilientHttpClientFactory
    {
        private readonly ILogger<ResilientHttpClient> _logger;
        private readonly int _retryCount;
        private readonly int _exceptionsAllowedBeforeBreaking;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResilientHttpClientFactory(ILogger<ResilientHttpClient> logger, IHttpContextAccessor httpContextAccessor, int exceptionsAllowedBeforeBreaking = 5, int retryCount = 6)
        {
            _logger = logger;
            _exceptionsAllowedBeforeBreaking = exceptionsAllowedBeforeBreaking;
            _retryCount = retryCount;
            _httpContextAccessor = httpContextAccessor;
        }
        public ResilientHttpClient CreateResilientHttpClient()=>
          new ResilientHttpClient(_logger, (origin) => CreatePolicies(), _httpContextAccessor);
        

        private Policy[] CreatePolicies()
        {
            return new Policy[] {
                
                //等待重试
                Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(
                    //重试的次数
                    _retryCount,
                    //每次出现异常重试的等待时间
                    retryAttemp=>TimeSpan.FromSeconds(Math.Pow(2,retryAttemp)),
                    //重试的事件
                    (exception,timeSpan,retryCount,context)=>{
                         var msg = $"Retry {retryCount} implemented with Polly's RetryPolicy " +
                            $"of {context.PolicyKey} " +
                            $"at {context.ExecutionKey}, " +
                            $"due to: {exception}.";
                        _logger.LogWarning(msg);
                        _logger.LogDebug(msg);
                    } ),
                //熔断器
                Policy.Handle<HttpRequestException>()
                .CircuitBreakerAsync(
                    //熔断前的异常数
                    _exceptionsAllowedBeforeBreaking,
                    //当异常数满足条件后，容短器打开，并熔断1分钟
                    TimeSpan.FromMinutes(1),
                    (exception,duration)=>{
                         // on circuit opened
                        _logger.LogTrace("Circuit breaker opened");
                    },
                    ()=>{
                         // on circuit closed
                        _logger.LogTrace("Circuit breaker reset");
                    })
            };
        }


    }
}
