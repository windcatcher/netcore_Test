using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.ViewModel;
using Newtonsoft.Json;
using Resilience.Http;

namespace MvcClient.Controllers
{

    public class ProductController : Controller
    {
        private IHttpClient _httpClient;
        private ILogger<ProductController> _logger;

        public ProductController(IHttpClient httpClient
            , ILogger<ProductController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetColors()
        {
            var urlProduct = "http://localhost:8802/api/colors";
            var dataString = await _httpClient.GetStringAsync(urlProduct);
            return Json(dataString);
        }

       // [Authorize]
        public async Task<IActionResult> GetOrders()
        {
            //var urlProduct = "http://localhost:8803/api/orders";
            var urlProduct = "http://localhost:5000/api/orders";
            var dataString = await _httpClient.GetStringAsync(urlProduct);
            return Json(dataString);
        }

        [Authorize]
        public async Task<IActionResult> GetSkus()
        {
            //
            var urlProduct = "http://localhost:8802/api/skus";
            var dataString = await _httpClient.GetStringAsync(urlProduct);
            var json = JsonConvert.DeserializeObject<List<SkuViewModel>>(dataString);
            return Json(json);
        }


        [Authorize]
        public IActionResult GetProducts()
        {
            return Json("GetProducts");
        }

    }
}