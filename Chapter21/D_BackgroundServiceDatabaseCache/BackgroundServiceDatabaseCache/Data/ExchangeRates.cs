using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackgroundServiceDatabaseCache
{
    public class ExchangeRates
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExchangeRatesId { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public ICollection<ExchangeRateValues> Rates { get; set; }
    }
}
