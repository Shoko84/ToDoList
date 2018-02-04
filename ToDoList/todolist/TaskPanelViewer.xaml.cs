using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace todolist
{
    /// <summary>
    /// Interaction logic for TaskPanelViewer.xaml
    /// </summary>
    public partial class TaskPanelViewer : UserControl
    {
        /// <summary>
        /// Graphic tasks list
        /// </summary>
        public List<TaskPanel> TaskPanels { get; set; }
        /// <summary>
        /// Task filtering informations
        /// </summary>
        public FilterInfo      FilterInfo { get; set; }

        /// <summary>
        /// Constructor of the <see cref="TaskPanelViewer"/> class
        /// </summary>
        public TaskPanelViewer()
        {
            InitializeComponent();
            TaskPanels = new List<TaskPanel>();
            FilterInfo = new FilterInfo(true, true);

            AddHandler(TaskPanel.TaskEditEventFromPanel,
                       new RoutedEventHandler(TaskEditEventFromPanelEventHandler));
            AddHandler(TaskPanel.TaskDeleteEventFromPanel,
                       new RoutedEventHandler(TaskDeleteEventFromPanelEventHandler));
            AddHandler(TaskPanel.TaskCompletedEventFromPanel,
                       new RoutedEventHandler(TaskCompletedEventFromPanelHandler));
        }

        /// <summary>
        /// Add a <see cref="TaskInfo"/> to the list of panels
        /// </summary>
        /// <param name="taskInfo">Task informations</param>
        public void AddTask(TaskInfo taskInfo)
        {
            TaskPanels.Add(new TaskPanel(taskInfo));
            RefreshTaskPanelsOnScreen();
        }

        /// <summary>
        /// Add multiple <see cref="TaskInfo"/> to the list of panels
        /// </summary>
        /// <param name="taskInfos">A list of task informations</param>
        public void AddTasks(List<TaskInfo> taskInfos)
        {
            for (var i = 0; i < taskInfos.Count; ++i)
                AddTask(taskInfos[i]);
            RefreshTaskPanelsOnScreen();
        }

        /// <summary>
        /// Reset and assign a list of <see cref="TaskInfo"/> to the list of panels
        /// </summary>
        /// <param name="taskInfos">A list of task informations</param>
        public void SetTasks(List<TaskInfo> taskInfos)
        {
            TaskPanels.Clear();
            AddTasks(taskInfos);
        }

        /// <summary>
        /// Apply a filter to the panel viewer
        /// </summary>
        /// <param name="filterInfo"></param>
        public void ApplyFilter(FilterInfo filterInfo)
        {
            FilterInfo = filterInfo;
            RefreshTaskPanelsOnScreen();
        }

        /// <summary>
        /// Refresh on screen task panels
        /// </summary>
        private void RefreshTaskPanelsOnScreen()
        {
            TaskPanelsContainer.Children.Clear();
            for (var i = 0; i < TaskPanels.Count; ++i)
            {
                if ((FilterInfo.ShowTodo && !TaskPanels[i].Info.Completed) ||
                    (FilterInfo.ShowDone && TaskPanels[i].Info.Completed))
                TaskPanelsContainer.Children.Add(TaskPanels[i]);
            }
        }

        /// <summary>
        /// Event raised when the user clicked on the 'Confirm' button when editing a task
        /// </summary>
        public static readonly RoutedEvent TaskEditEventFromPanelViewer =
            EventManager.RegisterRoutedEvent("TaskEditEventFromPanelViewer", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanelViewer));

        /// <summary>
        /// Event raised when the user clicked on the 'Confirm' button when deleting a task
        /// </summary>
        public static readonly RoutedEvent TaskDeleteEventFromPanelViewer =
            EventManager.RegisterRoutedEvent("TaskDeleteEventFromPanelViewer", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanelViewer));

        /// <summary>
        /// Event raised when the user clicked on the 'Done' button inside a task panel
        /// </summary>
        public static readonly RoutedEvent TaskCompletedEventFromPanelViewer =
            EventManager.RegisterRoutedEvent("TaskCompletedEventFromPanelViewer", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanelViewer));

        /// <summary>
        /// Function triggered when the panel body is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void TaskEditEventFromPanelEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            RaiseEvent(new TaskInfoArgs(TaskPanelViewer.TaskEditEventFromPanelViewer, args.TaskInfo));
        }

        /// <summary>
        /// Function triggered when the 'Trash' icon on the panel is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void TaskDeleteEventFromPanelEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            RaiseEvent(new TaskInfoArgs(TaskPanelViewer.TaskDeleteEventFromPanelViewer, args.TaskInfo));
        }

        /// <summary>
        /// Function triggered when the user clicked on the 'Done' button inside a task panel
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void TaskCompletedEventFromPanelHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            RaiseEvent(new TaskInfoArgs(TaskPanelViewer.TaskCompletedEventFromPanelViewer, args.TaskInfo));
        }
    }
}
