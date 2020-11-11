using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public void OnGet()
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "The validation succeeded, but here's a model error for you!");
            }
        }

        public class InputModel
        {
            public byte Byte { get; set; } = 16;
            public int Int { get; set; } = 23;
            public string String { get; set; } = "Some text";
            [DataType(DataType.Text), Display(Name = "Int as text")]
            public int IntAsText { get; set; } = 23;
            [HiddenInput]
            public string HiddenInput { get; set; } = "Some text";
            [DataType(DataType.Password)]
            public string Password { get; set; } = "Some text";
            [Phone]
            public string Phone { get; set; } = "12345678";
            [EmailAddress]
            public string Email { get; set; } = "test@example.com";
            [Url]
            public string Url { get; set; } = "https://andrewlock.net";
            [DataType(DataType.Date), Display(Name = "String as date")]
            public string StringAsDate { get; set; } = "12345678";
            [DataType(DataType.Date), Display(Name = "String as date")]
            public DateTime DateTime { get; set; } = DateTime.Now;
            public bool Boolean { get; set; } = true;
            public decimal Decimal { get; set; } = 1.23m;
            public double Double { get; set; } = 1.23;
            public float Float { get; set; } = 1.23F;
            [Required]
            [StringLength(200)]
            public string Multiline { get; set; } = @"This is some text, 
I'm going to display it 
in a text area";

        }
    }
}
