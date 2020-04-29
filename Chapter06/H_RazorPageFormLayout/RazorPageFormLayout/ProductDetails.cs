using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RazorPageFormLayout
{
    public class ProductDetails
    {
        public string ProductName { get; set; }
        public decimal SellPrice { get; set; }
        public int QuantityInStock { get; set; }

        public ProductDetails(string productName, decimal sellPrice, int qty)
        {
            ProductName = productName;
            SellPrice = sellPrice;
            QuantityInStock = qty;
        }
    }
}
