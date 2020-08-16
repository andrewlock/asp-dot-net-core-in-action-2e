using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Web.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {

        private readonly ICurrencyConverter _converter;
        public CurrencyController(ICurrencyConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        public ActionResult<decimal> Convert(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _converter.ConvertToGbp(
                model.Value,
                model.ExchangeRate,
                model.DecimalPlaces);

        }

        public class InputModel
        {
            [DisplayName("Value in GBP")]
            public decimal Value { get; set; } = 0;

            [DisplayName("Exchange rate from GBP to alternate currency")]
            [Range(0, double.MaxValue)]
            public decimal ExchangeRate { get; set; }

            [DisplayName("Round to decimal places")]
            [Range(0, int.MaxValue)]
            public int DecimalPlaces { get; set; }
        }
    }
}
