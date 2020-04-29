using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList
{

    public class ToDoItem
    {
        public ToDoItem(int id, params string[] tasks)
        {
            Id = id;
            Tasks = new List<string>(tasks);
        }

        public int Id { get; }
        public bool IsComplete => Tasks.Count == 0;
        public List<string> Tasks { get; }
    }
}
