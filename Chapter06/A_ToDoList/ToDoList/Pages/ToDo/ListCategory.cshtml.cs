using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoList.Pages.ToDo
{
    public class ListCategoryModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public IActionResult OnGet()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            //TODO: Validate the parameters
            var service = new ToDoService();
            Tasks = service.GetToDoItems(Input.Category, Input.Username)
                .Select(x => new Task(x.Number, x.Title));
            return Page();
        }


        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Category { get; set; }
        }

        public class Task
        {
            public Task(int id, string description)
            {
                Id = id;
                Description = description;
            }

            public int Id { get; }
            public string Description { get; set; }
        }
    }
}