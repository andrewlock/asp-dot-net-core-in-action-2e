using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoutingExample.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _service;

        public ProductsModel(ProductService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public Product Selected { get; set; }

        public IActionResult OnGet()
        {
            Selected = _service.GetProduct(Name);
            if(Selected is null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}