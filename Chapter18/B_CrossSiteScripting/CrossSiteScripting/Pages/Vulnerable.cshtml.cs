using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrossSiteScripting.Pages
{
    public class VulnerableModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        public void OnGet()
        {
            Name = DataService.GetMaliciousValue();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DataService.Data.Add(Name);
            return RedirectToPage("/vulnerable");
        }
    }
}
