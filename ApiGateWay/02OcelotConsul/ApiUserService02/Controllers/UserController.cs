using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiUserService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "User102", "User202" };
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
