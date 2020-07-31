using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsService
{
    public class ExchangeRateValues
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExchangeRateValuesId { get; set; }
        public string Rate { get; set; }
        public decimal Value { get; set; }
    }
}
