using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist
{
    public class TaskInfo
    {
        public TaskInfo(UInt32 id, string title = "", string content = "", DateTime? due = null, bool completed = false)
        {
            Id = id;
            Title = title;
            Content = content;
            Due = due;
            Completed = completed;
        }

        public TaskInfo(TaskInfo other)
        {
            Id = other.Id;
            Title = other.Title;
            Content = other.Content;
            Due = other.Due;
            Completed = other.Completed;
        }

        public UInt32 Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Due { get; set; }
        public bool Completed { get; set; }
    }
}
