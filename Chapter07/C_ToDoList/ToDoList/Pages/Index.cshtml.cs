using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoService _service;

        public IndexModel(ToDoService service)
        {
            _service = service;
        }

        public IEnumerable<ToDoItem> Items { get; set; }
        public void OnGet()
        {
            Items = _service.AllItems;
        }
    }
}
