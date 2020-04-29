using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurrencyConverter.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("Success");
        }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "Maximum length is {1}")]
            [Display(Name = "Your name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Maximum length is {1}")]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone(ErrorMessage = "Not a valid phone number.")]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }
    }
}