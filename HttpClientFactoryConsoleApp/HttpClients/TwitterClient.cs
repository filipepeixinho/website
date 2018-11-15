using HttpClientFactoryConsoleApp.Model;
using HttpClientFactoryConsoleApp.Services;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryConsoleApp.HttpClients
{
    public class TwitterClient : ITwitterClient
    {
        private readonly HttpClient _TokenClient;
        private readonly HttpClient _TwitterClient;
        private readonly IHttpUtils _httpUtils;
        private TwitterToken twitterToken;

        public TwitterClient(IHttpClientFactory httpClientFactory, IHttpUtils httpUtils)
        {
            _TokenClient = httpClientFactory.CreateClient("tokenclient");
            _TwitterClient = httpClientFactory.CreateClient("twitterclient");
            _httpUtils = httpUtils;

            string twitterKey = WebUtility.UrlEncode("uKv");
            string twitterSecret = WebUtility.UrlEncode("ssbP");
            string encodedKey = httpUtils.ConvertToBase64String($"{twitterKey}:{twitterSecret}");

            _TokenClient.BaseAddress = new Uri("https://api.twitter.com/");
            _TokenClient.DefaultRequestHeaders.Add("Authorization", $"Basic {encodedKey}");

            twitterToken = GetAuthToken().GetAwaiter().GetResult();

            _TwitterClient.BaseAddress = new Uri("https://api.twitter.com/");
            _TwitterClient.DefaultRequestHeaders.Add("Authorization", $"{twitterToken.Token_type} {twitterToken.Access_token}");
        }

        public async Task<Tweet[]> GetTweets(string username)
        {
            var result = await _TwitterClient.GetAsync($"/1.1/statuses/user_timeline.json?count=100&screen_name={username}");

            var strResult = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Tweet[]>(strResult);
        }

        private async Task<TwitterToken> GetAuthToken()
        {
            HttpResponseMessage result = await _TokenClient.PostAsync("/oauth2/token", new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded"));
            string strResult = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TwitterToken>(strResult);
        }
    }
}
