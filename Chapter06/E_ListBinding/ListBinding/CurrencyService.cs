using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListBinding
{
    public class CurrencyService
    {
        public static readonly Dictionary<string, decimal> AllCurrencies =
            new Dictionary<string, decimal>
            {
                {"GBP", 1.00m},
                {"USD", 1.22m},
                {"CAD", 1.64m},
                {"EUR", 1.15m},
            };
    }
}
