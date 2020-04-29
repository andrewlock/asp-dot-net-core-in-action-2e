using System.Collections.Generic;

namespace PartialViews
{
    public class ToDoItemViewModel
    {
        public ToDoItemViewModel(int id, string title, params string[] tasks)
        {
            Id = id;
            Tasks = new List<string>(tasks);
            Title = title;
        }

        public int Id { get; }
        public string Title { get; }
        public bool IsComplete => Tasks.Count == 0;
        public List<string> Tasks { get; }
    }
}
