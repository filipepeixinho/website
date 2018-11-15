using HttpClientFactoryConsoleApp.HttpClients;
using HttpClientFactoryConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace HttpClientFactoryConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                  .AddLogging(options =>
                  {
                      options.AddConsole().SetMinimumLevel(LogLevel.Debug);
                  })
                  .AddHttpClient()
                  .AddSingleton<ITwitterClient, TwitterClient>()
                  .AddSingleton<ITwitterService, TwitterService>()
                  .AddSingleton<IHttpUtils, HttpUtils>()
                  .BuildServiceProvider();

            ILogger<Program> logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application...");

            //Do the work
            ITwitterService httpUtils = serviceProvider.GetService<ITwitterService>();
            var result = httpUtils.GetTweets("fiho").GetAwaiter().GetResult();

            foreach (var tweet in result)
            {
                Console.WriteLine(tweet.ToString());
                Console.WriteLine("=================================================================================================================");
            }


            logger.LogDebug("The end...");

            Console.ReadLine();
        }
    }
}
