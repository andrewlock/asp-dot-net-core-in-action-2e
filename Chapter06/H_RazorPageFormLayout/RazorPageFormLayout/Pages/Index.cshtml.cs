using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageFormLayout.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ProductService _productService;
        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public Dictionary<int, ProductDetails> Products { get; private set; }

        public void OnGet()
        {
            Products = _productService._products;
        }
    }
}
