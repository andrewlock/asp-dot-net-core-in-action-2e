using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoList.Pages
{
    public class ViewToDoModel : PageModel
    {
        private readonly ToDoService _service;

        public ToDoItem ToDo { get; set; }

        public ViewToDoModel(ToDoService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            ToDo = _service.AllItems.FirstOrDefault(x => x.Id == id);
            if (ToDo == null)
            {
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}