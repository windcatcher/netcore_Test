using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiUserService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IOptions<ServiceDisvoveryOptions> _options;
        private readonly ILogger<UserController> _logger;


        public UserController(IOptions<ServiceDisvoveryOptions> options, ILogger<UserController> logger)
        {
            _options = options;
            _logger = logger;
        }

        // GET api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var userUri = new Uri(_options.Value.RegisterServerUrl);
            var ipAdress = System.Net.Dns.GetHostAddresses(userUri.Host).Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            var serviceId = $"{ipAdress.ToString()}_{userUri.Port}";
            _logger.LogInformation($"serviceId:{serviceId}");
            return new string[] { serviceId + "User1", serviceId+"User2" };
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/User
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
