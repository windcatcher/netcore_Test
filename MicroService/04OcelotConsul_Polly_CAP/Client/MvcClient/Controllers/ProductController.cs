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
using Microsoft.Extensions.Options;
using MvcClient.Options;
using MvcClient.ViewModel;
using Newtonsoft.Json;
using Resilience.Http;

namespace MvcClient.Controllers
{

    public class ProductController : Controller
    {
        private IHttpClient _httpClient;
        private ILogger<ProductController> _logger;
        private readonly IOptions<AppSettinOptions> _options;
        public ProductController(IHttpClient httpClient
            , ILogger<ProductController> logger, IOptions<AppSettinOptions> options)
        {
            _httpClient = httpClient;
            _logger = logger;
            _options = options;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetColors()
        {
            //var urlProduct = $"{_options.Value.ProductUrl}/api/colors";
            var urlProduct = $"http://product_service/api/colors";
            var dataString = await _httpClient.GetStringAsync(urlProduct);
            return Json(dataString);
        }

       // [Authorize]
        public async Task<IActionResult> GetOrders()
        {
            //var urlProduct = "http://localhost:8803/api/orders";
            var urlProduct = $"{_options.Value.OrderUrl}/api/orders";
            var dataString = await _httpClient.GetStringAsync(urlProduct);
            return Json(dataString);
        }

        [Authorize]
        public async Task<IActionResult> GetSkus()
        {
            //
            var urlProduct = $"{_options.Value.ProductUrl}/api/skus";
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