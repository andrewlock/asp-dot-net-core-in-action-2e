using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PartialViews
{
    public static class TaskService
    {
        //This list would be loaded from a database or file etc
        public static List<ToDoItemViewModel> AllTasks { get; } = new List<ToDoItemViewModel>
        {
            new ToDoItemViewModel(1, "Shopping List", "Buy milk", "Buy eggs", "Buy bread"),
            new ToDoItemViewModel(2, "Agenda", "Pick up kids", "Take kids to school"),
            new ToDoItemViewModel(4, "Car stuff", "Get fuel", "Check oil", "Check Tyre pressure"),
            new ToDoItemViewModel(4, "Problems"),
            new ToDoItemViewModel(5, "Writing tasks","Write blog post", "Edit book chapter"),
        };

    }
}
