using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageUsers.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// WARNING: For demo only, not thread safe, you would store these values in a database etc
        /// </summary>
        private static readonly List<string> _users = new List<string>
        {
            "Bart",
            "Jimmy",
            "Robbie"
        };

        [BindProperty, Required]
        public string NewUser{ get; set; }
        public List<String> ExistingUsers { get; set; }

        public void OnGet()
        {
            ExistingUsers = _users;
        }

        public IActionResult OnPost()
        {
            ExistingUsers = _users;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_users.Contains(NewUser))
            {
                //Note, you would typically extract this to a validation attribute
                //But I do it here as the users list is hard coded above
                ModelState.AddModelError(nameof(NewUser), "This user already exists!");
                return Page();
            }

            //all ok, add the user and clear the existing value
            _users.Insert(0, NewUser);
            return RedirectToPage();
        }

        public class InputModel
        {
            public List<string> ExistingUsers { get; set; }
            public string NewUser { get; set; }
        }

    }
}
