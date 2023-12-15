using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BaseClientHelper
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public BaseClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //   baseURL = _configuration.GetValue<string>("BASE_URL");
        }
        public async Task<HttpResponseMessage> GetTTTAsync(string path, AuthenticationHeaderValue auth = default,
            Dictionary<string, string> headers = default)
        {
            using (var client = new HttpClient())
            {
                if (auth != null)
                    client.DefaultRequestHeaders.Authorization = auth;
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        client.DefaultRequestHeaders.Add(h.Key, h.Value);
                    }
                }

                return await client.GetAsync(path);
            }
        }
        public async Task<HttpResponseMessage> GetAsync(string path, AuthenticationHeaderValue auth = default,
            Dictionary<string, string> headers = default)
        {
            var client = _httpClientFactory.CreateClient();

            if (auth != null)
                client.DefaultRequestHeaders.Authorization = auth;
            if (headers != null)
            {
                foreach (var h in headers)
                {
                    client.DefaultRequestHeaders.Add(h.Key, h.Value);
                }
            }
            return await client.GetAsync(path);
        }


        public async Task<HttpResponseMessage> PostAsync<M>(M detail, string path,
            AuthenticationHeaderValue auth = default,
            Dictionary<string, string> headers = default)
        {
            using (var client = new HttpClient())
            {
                var jsonContent = JsonConvert.SerializeObject(detail);
                var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        client.DefaultRequestHeaders.Add(h.Key, h.Value);
                    }
                }

                if (auth != null)
                    client.DefaultRequestHeaders.Authorization = auth;

                return await client.PostAsync(path, data);
            }
        }
        public async Task<HttpResponseMessage> PatchAsync<M>(M detail, string path,
         AuthenticationHeaderValue auth = default,
         Dictionary<string, string> headers = default)
        {
            using (var client = new HttpClient())
            {
                var jsonContent = JsonConvert.SerializeObject(detail);
                var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        client.DefaultRequestHeaders.Add(h.Key, h.Value);
                    }
                }

                if (auth != null)
                    client.DefaultRequestHeaders.Authorization = auth;

                return await client.PatchAsync(path, data);
            }
        }
        public async Task<HttpResponseMessage> PostAsync(Dictionary<string, string> body, string path,
            AuthenticationHeaderValue? auth = default,
            Dictionary<string, string> headers = default)
        {
            using (var client = new HttpClient())
            {
                var data = new FormUrlEncodedContent(body);

                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        client.DefaultRequestHeaders.Add(h.Key, h.Value);
                    }
                }

                if (auth != null)
                    client.DefaultRequestHeaders.Authorization = auth;

                return await client.PostAsync(path, data);
            }
        }
    }
}