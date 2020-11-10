using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageHandlers
{
    public class SearchModel : PageModel
    {
        private readonly SearchService _searchService;
        public SearchModel(SearchService searchService)
        {
            _searchService = searchService;
        }

        [BindProperty]
        public BindingModel Input { get; set; }
        public List<Product> Results { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Results = _searchService.SearchProducts(Input.SearchTerm);
                return Page();
            }
            return RedirectToPage();
        }

        public class BindingModel
        {
            [Required]
            public string SearchTerm { get; set; }
        }
    }
}