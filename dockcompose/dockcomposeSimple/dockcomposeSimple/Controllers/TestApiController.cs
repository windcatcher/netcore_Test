using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace dockcomposeSimple.Controllers
{
    public class TestApiController : Controller
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;

        public TestApiController(IOptionsSnapshot<AppSettings> settings)
        {
            _settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var testapiClient = _settings.Value.TestApiClent;
            Uri.TryCreate(testapiClient, UriKind.RelativeOrAbsolute, out Uri uri1);

            var ipEndPoint = GetHostIpEndPoint(uri1.DnsSafeHost, uri1.Port);
            var url = $"http://{ipEndPoint.Address}:{ipEndPoint.Port}";
            //var originUrl = $"{url}/api/values";
            var originUrl = $"{testapiClient}/api/values";
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync(originUrl);
                return Ok(result);
            }
        }

        private IPEndPoint GetHostIpEndPoint(string hostName, string aspcoreUrl)
        {
            IPAddress[] ipaddress = Dns.GetHostAddresses(hostName);
            var hostip = ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            Uri.TryCreate(aspcoreUrl, UriKind.Absolute, out Uri uri);
            return new IPEndPoint(hostip, uri.Port);
        }


        private IPEndPoint GetHostIpEndPoint(string hostName, int port)
        {
            IPAddress[] ipaddress = Dns.GetHostAddresses(hostName);
            var hostip = ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            return new IPEndPoint(hostip, port);
        }

    }
}