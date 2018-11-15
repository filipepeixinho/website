using HttpClientFactoryConsoleApp.HttpClients;
using HttpClientFactoryConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryConsoleApp.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly ITwitterClient _twitterClient;

        public TwitterService(ITwitterClient twitterClient)
        {
            _twitterClient = twitterClient;
        }
        public async Task<Tweet[]> GetTweets(string username)
        {
            var result = await _twitterClient.GetTweets(username);

            return result;
        }
    }
}
