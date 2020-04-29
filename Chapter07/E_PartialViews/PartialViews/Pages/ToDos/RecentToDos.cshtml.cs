using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PartialViews.Pages.ToDos
{
    public class RecentToDosModel : PageModel
    {
        public int RecentToDosToDisplay { get; } = 3;

        public IEnumerable<ToDoItemViewModel> RecentToDos { get; set; }

        public void OnGet()
        {
            RecentToDos = TaskService.AllTasks.Take(RecentToDosToDisplay);
        }
    }
}
