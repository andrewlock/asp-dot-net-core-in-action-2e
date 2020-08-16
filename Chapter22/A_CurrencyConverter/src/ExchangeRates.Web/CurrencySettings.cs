using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExchangeRates.Web
{
    public class CurrencySettings
    {
        public decimal DefaultValue { get; set; }
        public decimal DefaultExchangeRate { get; set; }
        public int DefaultDecimalPlaces { get; set; }
    }
}
