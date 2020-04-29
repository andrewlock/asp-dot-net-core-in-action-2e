using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleCalculatorBinding.Pages
{
    public class CalculateSquareModel : PageModel
    {
        // Note, could use [BindProperty(SupportsGet = true)] here instead of 'value' argument in OnGet
        public int Input { get; set; }
        public int Square { get; set; }
        
        public void OnGet(int number)
        {
            Square = number * number;
            Input = number;
        }
    }
}