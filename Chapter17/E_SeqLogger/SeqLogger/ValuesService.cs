using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace SeqLogger
{
    public class ValuesService
    {
        public readonly ILogger<ValuesService> _logger;
        public ValuesService(ILogger<ValuesService> logger)
        {
            _logger = logger;
        }
        public IEnumerable<string> GetValues()
        {
            _logger.LogInformation("Inside service, outside scope");
            using (_logger.BeginScope(new Dictionary<string, object> { { "ScopeValue2", "inner scope" } }))
            {
                _logger.LogInformation("Inside service, inside scope");
                return new string[] { "value1", "value2" };
            }
        }
    }
}
