using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace todolist
{
    public class TaskPanelArgs : RoutedEventArgs
    {
        private readonly TaskInfo taskInfo;

        public TaskInfo TaskInfo
        {
            get { return taskInfo; }
        }

        public TaskPanelArgs(RoutedEvent routedEvent, TaskInfo taskInfo) : base(routedEvent)
        {
            this.taskInfo = taskInfo;
        }
    }
}
