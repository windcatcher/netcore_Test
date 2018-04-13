using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProductService.config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiProductService.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IOptions<ServiceDisvoveryOptions> _options;

        public ProductController(IOptions<ServiceDisvoveryOptions> options)
        {
            _options = options;
        }

        // GET api/Product
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var userUri = new Uri(_options.Value.RegisterServerUrl);
            var ipAdress = System.Net.Dns.GetHostAddresses(userUri.Host).Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            var serviceId = $"{ipAdress.ToString()}_{userUri.Port}";
            return new string[] { serviceId + "Product1", serviceId + "Product2" };
        }

        // GET api/Product/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Product
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
