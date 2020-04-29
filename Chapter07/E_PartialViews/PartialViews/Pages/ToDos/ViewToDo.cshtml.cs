using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PartialViews.Pages.ToDos
{
    public class ViewToDoModel : PageModel
    {
        public ToDoItemViewModel Item { get; set; }

        public IActionResult OnGet(int id)
        {
            Item = TaskService.AllTasks.FirstOrDefault(x => x.Id == id);
            if (Item == null)
            {
                return RedirectToPage("RecentToDos");
            }
            return Page();
        }
    }
}
