using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace webapi_redis_docker.Controllers {
    [Route ("api/[controller]")]
    public class HomeController : Controller {
        private readonly IDistributedCache _distributedCache;
        public HomeController (IDistributedCache distributedCache) {
            _distributedCache = distributedCache;
        }
        // GET api/home
        [HttpGet]
        public string Get () {
            string cachekey = "thetime";
            string existingTime = _distributedCache.GetString (cachekey);
            if (string.IsNullOrEmpty (existingTime)) {
                existingTime = DateTime.UtcNow.ToString ();
                _distributedCache.SetString (cachekey, existingTime);
                return "添加到缓存 : " + existingTime;
            } else {
                return "从缓存中获取" + existingTime;
            }
        }
    }
}