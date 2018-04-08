using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductService.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        // GET api/Product
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Product1", "Product2" };
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
