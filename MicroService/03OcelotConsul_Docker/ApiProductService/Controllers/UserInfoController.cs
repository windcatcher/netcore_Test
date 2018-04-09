using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiProductService.config;
using DnsClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiProductService.Controllers
{
    /// <summary>
    /// 服务间的调用，调用user api的服务
    /// </summary>
    [Route("api/product/[Controller]")]
    public class UserInfoController : Controller
    {
        private readonly IDnsQuery _dns;
        private readonly IOptions<ServiceDisvoveryOptions> _options;


        public UserInfoController(IDnsQuery dns, IOptions<ServiceDisvoveryOptions> options)
        {
            _dns = dns ?? throw new ArgumentNullException(nameof(dns));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }
        [HttpGet("")]
        [HttpHead("")]
        public async Task<string> Get()
        {
            var result = await _dns.ResolveServiceAsync("service.consul", _options.Value.DiscoveryServiceName);
            var address = result.First();
            using (var client = new HttpClient())
            {
                var _userApiUrl = $"http://{address.HostName}:{address.Port}";
                var serviceResult = await client.GetStringAsync($"{_userApiUrl}/api/user");
                return serviceResult;
            }
        }
    }

}