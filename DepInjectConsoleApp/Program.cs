using DepInjectConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DepInjectConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Configure DI
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ISampleService, SampleService>()
                .AddSingleton<IAnotherSampleService, AnotherSampleService>()
                .BuildServiceProvider();


            //configure console log
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            ILogger<Program> logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application...");

            //Do the work
            ISampleService sampleSrv = serviceProvider.GetService<ISampleService>();
            int result = sampleSrv.MultiplyAndAdd(3, 5);

            Console.WriteLine($"Result: {result}");

            logger.LogDebug("The end...");

        }
    }
}
