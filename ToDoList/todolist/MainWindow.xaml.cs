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
using System.Windows.Controls.Primitives;

namespace todolist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskPanelViewer     _taskPanelViewer;
        AddTaskControl      _addTaskControl;
        EditTaskControl     _editTaskControl;

        public MainWindow()
        {
            InitializeComponent();
            _taskPanelViewer = new TaskPanelViewer();
            MainContentArea.Content = _taskPanelViewer;

            AddHandler(TaskPanelViewer.TaskEditEventFromPanelViewer,
                       new RoutedEventHandler(TaskEditEventFromMainWindowHandler));
            AddHandler(TaskPanelViewer.TaskDeleteEventFromPanelViewer,
                       new RoutedEventHandler(TaskDeleteEventFromMainWindowHandler));
            AddHandler(AddTaskControl.AddTaskConfirmEvent,
                       new RoutedEventHandler(AddTaskConfirmEventHandler));
            AddHandler(AddTaskControl.AddTaskCancelEvent,
                       new RoutedEventHandler(AddTaskCancelEventHandler));
            AddHandler(EditTaskControl.EditTaskConfirmEvent,
                       new RoutedEventHandler(EditTaskConfirmEventHandler));
            AddHandler(EditTaskControl.EditTaskCancelEvent,
                       new RoutedEventHandler(EditTaskCancelEventHandler));
        }

        // Local events
        private void AddTaskButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _addTaskControl = new AddTaskControl(Convert.ToUInt32(_taskPanelViewer.TaskPanels.Count));
            AddTaskButton.Visibility = Visibility.Hidden;
            MainContentArea.Content = _addTaskControl;

        }

        // Signals handler
        private void TaskEditEventFromMainWindowHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            _editTaskControl = new EditTaskControl(args.TaskInfo);
            AddTaskButton.Visibility = Visibility.Hidden;
            MainContentArea.Content = _editTaskControl;
        }
        private void TaskDeleteEventFromMainWindowHandler(object sender, RoutedEventArgs e)
        {
            // New user control for confirmation ?
            TaskInfoArgs args = e as TaskInfoArgs;

            _taskPanelViewer.DeleteTask(args.TaskInfo);
        }

        private void AddTaskConfirmEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            _taskPanelViewer.AddTask(args.TaskInfo);
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        private void AddTaskCancelEventHandler(object sender, RoutedEventArgs e)
        {
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        private void EditTaskConfirmEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            _taskPanelViewer.EditTask(args.TaskInfo);
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        private void EditTaskCancelEventHandler(object sender, RoutedEventArgs e)
        {
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }
    }
}
