using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATypicalRazorPage
{
    public class CategoryModel : PageModel
    {
        private readonly ToDoService _service;
        public List<ToDoListModel> Items { get; set; }

        public CategoryModel(ToDoService service)
        {
            _service = service;
        }

        public ActionResult OnGet(string category)
        {
            Items = _service.GetItemsForCategory(category);
            return Page();
        }
    }
}