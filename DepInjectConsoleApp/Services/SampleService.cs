using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepInjectConsoleApp.Services
{
    public class SampleService : ISampleService
    {
        private readonly IAnotherSampleService _anotherSampleService;
        private readonly ILogger<SampleService> _logger; 

        public SampleService(IAnotherSampleService anotherSampleService, ILoggerFactory loggerFactory)
        {
            _anotherSampleService = anotherSampleService;
            _logger = loggerFactory.CreateLogger<SampleService>();
        }

        public int MultiplyAndAdd(int a, int b)
        {
            int resultFromAnotherSampleService = _anotherSampleService.Multiply(a, b);

            _logger.LogInformation($"Result from AnotherService: {resultFromAnotherSampleService}");

            return (a + b) * resultFromAnotherSampleService;
        }
    }
}
