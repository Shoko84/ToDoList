using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace todolist
{
    /// <summary>
    /// Interaction logic for TaskPanelViewer.xaml
    /// </summary>
    public partial class TaskPanelViewer : UserControl
    {
        public List<TaskPanel> TaskPanels { get; set; }

        public TaskPanelViewer()
        {
            InitializeComponent();
            TaskPanels = new List<TaskPanel>();

            AddHandler(TaskPanel.TaskEditEventFromPanel,
                       new RoutedEventHandler(TaskEditEventFromPanelEventHandler));

            AddHandler(TaskPanel.TaskDeleteEventFromPanel,
                       new RoutedEventHandler(TaskDeleteEventFromPanelEventHandler));
        }

        public void AddTask(TaskInfo taskInfo)
        {
            TaskPanels.Add(new TaskPanel(taskInfo));
            RefreshTaskPanelsOnScreen();
        }

        public void EditTask(TaskInfo taskInfo)
        {
            TaskPanels[Convert.ToInt32(taskInfo.Id)] = new TaskPanel(taskInfo);
            RefreshTaskPanelsOnScreen();
        }

        public void DeleteTask(TaskInfo taskInfo)
        {
            TaskPanels.RemoveAt(Convert.ToInt32(taskInfo.Id));
            RefreshTaskPanelsOnScreen();
        }

        private void RefreshTaskPanelsOnScreen()
        {
            TaskPanelsContainer.Children.Clear();
            for (var i = 0; i < TaskPanels.Count; ++i)
                TaskPanelsContainer.Children.Add(TaskPanels[i]);
        }

        //Event raising for a communication with the main window

        public static readonly RoutedEvent TaskEditEventFromPanelViewer =
            EventManager.RegisterRoutedEvent("TaskEditEventFromPanelViewer", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanelViewer));

        public static readonly RoutedEvent TaskDeleteEventFromPanelViewer =
            EventManager.RegisterRoutedEvent("TaskDeleteEventFromPanelViewer", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanelViewer));

        private void TaskEditEventFromPanelEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            RaiseEvent(new TaskInfoArgs(TaskPanelViewer.TaskEditEventFromPanelViewer, args.TaskInfo));
        }
        private void TaskDeleteEventFromPanelEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            RaiseEvent(new TaskInfoArgs(TaskPanelViewer.TaskDeleteEventFromPanelViewer, args.TaskInfo));
        }
    }
}
