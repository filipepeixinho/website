using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepInjectConsoleApp.Services
{
    public class AnotherSampleService : IAnotherSampleService
    {
        private readonly ILogger<AnotherSampleService> _logger;

        public AnotherSampleService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AnotherSampleService>();
        }

        public int Multiply(int a, int b)
        {
            _logger.LogInformation($"Multiplying {a} with {b}");
            return a * b;
        }
    }
}
