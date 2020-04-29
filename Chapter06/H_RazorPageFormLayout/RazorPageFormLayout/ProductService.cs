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

    public class ProductService
    {
        public readonly Dictionary<int, ProductDetails> _products = new Dictionary<int, ProductDetails>
        {
            {1, new ProductDetails("Apple iPod", 200, 50) },
            {2, new ProductDetails("Surface Book", 2200, 10) },
            {3, new ProductDetails("XPS 15", 1600, 3) },
        };
            
        public ProductDetails GetProduct(int productId)
        {
            if(_products.TryGetValue(productId, out var product))
            {
                return product;
            }
            return null;
        }

        public void UpdateProduct(int productId, string newName, decimal newSellPrice)
        {
            var product = GetProduct(productId);
            if (product is null)
            {
                return;
            }

            product.ProductName = newName;
            product.SellPrice = newSellPrice;
        }
    }
}
