using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertingToMVC
{
    public class CategoryViewModel
    {
        public List<ToDoListModel> Items { get; set; }

        public CategoryViewModel(List<ToDoListModel> items)
        {
            Items = items;
        }
    }
}
