using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleClient
{
    [Route("[controller]/[Action]")]
    public class ProductController : Controller
    {
        private HttpClient _httpClient;
        private string _gateWayUrl;
        private IOptionsSnapshot<AppSetting> _appSetting;

        public ProductController(HttpClient httpClient, IOptionsSnapshot<AppSetting> appSetting)
        {
            _appSetting = appSetting;
            _httpClient = httpClient;
            _gateWayUrl = appSetting.Value.GatewayUrl;
        }

        [HttpGet]
        // GET: /product/ownerpassword
        public async Task<IActionResult> OwnerPassword()
        {
            var result = await UseHttpClientPassword();
            return Ok(result);
        }

        [HttpGet]
        // GET: /product/clientcredential
        public async Task<IActionResult> ClientCredential()
        {
            var result = await UseHttpClientClientCredential();
            return Ok(result);
        }

        [HttpGet]
        // GET: /product/userinfo
        public async Task<IActionResult> UserInfo()
        {
            var result = await UseHttpClientClientCredential("/product/userinfo");
            return Ok(result);
        }

        private async Task<string> UseHttpClientPassword()
        {
            var identityUrl = $"{_appSetting.Value.IdentityServerUrl}/connect/token";
            var token = "";
            var result = "";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", "client"),
                new KeyValuePair<string, string>("client_secret", "secret"),
                new KeyValuePair<string, string>("scopes", "api1"),
            });

            using (var client = new HttpClient())
            {
                var respResult = await _httpClient.PostAsync(identityUrl, content);
                string resultContent = await respResult.Content.ReadAsStringAsync();
                dynamic resultDyn = JsonConvert.DeserializeObject(resultContent);
                token = resultDyn.access_token.Value;
            }
            using (var client = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                result = await _httpClient.GetStringAsync($"{_gateWayUrl}/product");
            }
            return result;
        }


        private async Task<string> UseHttpClientClientCredential(string actionUrl= "/product")
        {
            var identityUrl = $"{_appSetting.Value.IdentityServerUrl}/connect/token";
            var token = "";
            var result = "";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_id", "ro.client"),
                new KeyValuePair<string, string>("client_secret", "secret"),
                new KeyValuePair<string, string>("username", "alice"),
                new KeyValuePair<string, string>("password", "alice"),
                new KeyValuePair<string, string>("scopes", "api1"),
            });

            using (var client = new HttpClient())
            {
                var respResult = await _httpClient.PostAsync(identityUrl, content);
                string resultContent = await respResult.Content.ReadAsStringAsync();
                dynamic resultDyn = JsonConvert.DeserializeObject(resultContent);
                token = resultDyn.access_token.Value;
            }
            using (var client = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                result = await _httpClient.GetStringAsync($"{_gateWayUrl}{actionUrl}");
            }
            return result;
        }
        private async Task<string> UseTokenClientClientCredential()
        {
            // var identityUrl = "http://localhost:8010/connect/token";
            //从元数据中发现客户端
            var disco = await DiscoveryClient.GetAsync(_appSetting.Value.IdentityServerUrl);
            //请求令牌
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
            if (tokenResponse.IsError)
                return tokenResponse.Error;

            //调用api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync($"{_gateWayUrl}/product");
            if (!response.IsSuccessStatusCode)
                return response.StatusCode.ToString();
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }


        private async Task<string> UseTokenClientPassword()
        {
            // var identityUrl = "http://localhost:8010/connect/token";
            //从元数据中发现客户端
            var disco = await DiscoveryClient.GetAsync(_appSetting.Value.IdentityServerUrl);
            //请求令牌
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "alice", "api1");
            if (tokenResponse.IsError)
                return tokenResponse.Error;

            //调用api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync($"{_gateWayUrl}/product");
            if (!response.IsSuccessStatusCode)
                return response.StatusCode.ToString();
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

    }
}
