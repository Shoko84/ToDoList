using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace todolist
{
    /// <summary>
    /// Class used to send tasks over raised events
    /// </summary>
    public class TaskInfoArgs : RoutedEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly TaskInfo taskInfo;

        /// <summary>
        /// Getter for the task informations
        /// </summary>
        public TaskInfo TaskInfo
        {
            get { return taskInfo; }
        }

        /// <summary>
        /// Constructor of the <see cref="TaskInfoArgs"/> class
        /// </summary>
        /// <param name="routedEvent">An <see cref="RoutedEvent"/></param>
        /// <param name="taskInfo">Task informations to be sent</param>
        public TaskInfoArgs(RoutedEvent routedEvent, TaskInfo taskInfo) : base(routedEvent)
        {
            this.taskInfo = taskInfo;
        }
    }
}
