using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleBinding.Pages
{
    [IgnoreAntiforgeryToken] // So you can call the page from Postman etc
    public class EditProductModel : PageModel
    {
        public ProductModel Product { get; set; }

        public void OnGet()
        {

        }

        public void OnPost(ProductModel product)
        {
            Product = product;
        }

        public void OnPostEditTwoProducts(ProductModel product1, ProductModel product2)
        {
            Product = product1;
        }
    }
}