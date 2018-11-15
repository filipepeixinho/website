using HttpClientFactoryConsoleApp.Model;
using System.Threading.Tasks;

namespace HttpClientFactoryConsoleApp.Services
{
    public interface ITwitterService
    {
        Task<Tweet[]> GetTweets(string username);
    }
}