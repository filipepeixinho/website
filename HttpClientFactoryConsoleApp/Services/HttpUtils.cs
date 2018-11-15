using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryConsoleApp.Services
{
    public class HttpUtils : IHttpUtils
    {
        IHttpClientFactory _clientFactory;

        public HttpUtils(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public async Task<string> GetUrl(string url)
        {
            var client = _clientFactory.CreateClient();

            var result = await client.GetStringAsync(url);

            return "result";
        }

        public string ConvertToBase64String(string url)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(url);
            return System.Convert.ToBase64String(textBytes);                
        }
    }
}
