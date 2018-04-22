using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Resilience.Http
{
    public class StandardHttpClient : IHttpClient
    {
        private HttpClient _client;
        private IHttpContextAccessor _httpContextAccessor;
        private ILogger<StandardHttpClient> _logger;

        public StandardHttpClient(IHttpContextAccessor httpContextAccessor, ILogger<StandardHttpClient> logger)
        {
            _client = new HttpClient();
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

      

        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, uri);
            SetAuthorizationHeader(requestMsg);
            if (authorizationToken != null)
                requestMsg.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);

            var response = await _client.SendAsync(requestMsg);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            return await DoPostAsync(HttpMethod.Post, uri, item, authorizationToken, requestId, authorizationMethod);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            return await DoPostAsync(HttpMethod.Put, uri, item, authorizationToken, requestId, authorizationMethod);
        }


        public async Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            SetAuthorizationHeader(requestMessage);

            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }

            if (requestId != null)
            {
                requestMessage.Headers.Add("x-requestid", requestId);
            }

            return await _client.SendAsync(requestMessage);
        }
        public async Task<HttpResponseMessage> DoPostAsync<T>(HttpMethod method, string uri, T item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
            {
                throw new ArgumentException("Value must be either post or put.", nameof(method));
            }

            var requestMsg = new HttpRequestMessage(method, uri);
            SetAuthorizationHeader(requestMsg);
            requestMsg.Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

            if (authorizationToken != null)
                requestMsg.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);

            if (requestId != null)
                requestMsg.Headers.Add("x-requestid", requestId);

            // raise exception if HttpResponseCode 500
            // needed for circuit breaker to track fails  此异常给熔断器使用
            var response = await _client.SendAsync(requestMsg);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }
            return response;
        }

      

        private void SetAuthorizationHeader(HttpRequestMessage requestMessage)
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                requestMessage.Headers.Add("Authorization", new List<string>() { authorizationHeader });
            }
        }
    }
}
