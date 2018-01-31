using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace todolist
{
    public class TaskInfoArgs : RoutedEventArgs
    {
        private readonly TaskInfo taskInfo;

        public TaskInfo TaskInfo
        {
            get { return taskInfo; }
        }

        public TaskInfoArgs(RoutedEvent routedEvent, TaskInfo taskInfo) : base(routedEvent)
        {
            this.taskInfo = taskInfo;
        }
    }
}
