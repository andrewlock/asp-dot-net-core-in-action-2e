using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RecipeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RecipeService _service;
        public IEnumerable<RecipeSummaryViewModel> Recipes { get; private set; }

        public IndexModel(RecipeService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            Recipes = await _service.GetRecipes();

        }
    }
}
