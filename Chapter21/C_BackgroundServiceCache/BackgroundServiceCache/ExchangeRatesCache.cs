using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Polly;

namespace BackgroundServiceCache
{
    public class ExchangeRatesCache
    {
        private ExchangeRates _rates;

        public ExchangeRates GetLatestRates()
        {
            // Could be null the first time it's requested
            return _rates;
        }

        public void SetRates(ExchangeRates newRates)
        {
            Interlocked.Exchange(ref _rates, newRates);
        }
    }
}
