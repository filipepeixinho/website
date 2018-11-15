using HttpClientFactoryConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryConsoleApp.HttpClients
{
    public interface ITwitterClient
    {
        Task<Tweet[]> GetTweets(string username);
    }
}
