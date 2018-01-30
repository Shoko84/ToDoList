using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist
{
    public class TaskInfo
    {
        public TaskInfo(string title = "", string content = "", DateTime? due = null, bool completed = false)
        {
            Title = title;
            Content = content;
            Due = due;
            Completed = completed;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Due { get; set; }
        public bool Completed { get; set; }
    }
}
