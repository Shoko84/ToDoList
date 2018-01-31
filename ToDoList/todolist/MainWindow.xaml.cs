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
        DeletionTaskControl _deletionTaskControl;

        public MainWindow()
        {
            InitializeComponent();
            _taskPanelViewer = new TaskPanelViewer();
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());
            MainContentArea.Content = _taskPanelViewer;

            AddHandler(TaskPanelViewer.TaskEditEventFromPanelViewer,
                       new RoutedEventHandler(TaskEditEventFromMainWindowHandler));
            AddHandler(TaskPanelViewer.TaskDeleteEventFromPanelViewer,
                       new RoutedEventHandler(TaskDeleteEventFromMainWindowHandler));
            AddHandler(TaskPanelViewer.TaskCompletedEventFromPanelViewer,
                       new RoutedEventHandler(TaskCompletedEventFromMainWindowHandler));
            AddHandler(DeletionTaskControl.DeleteTaskConfirmEvent,
                       new RoutedEventHandler(DeleteTaskConfirmEventHandler));
            AddHandler(DeletionTaskControl.DeleteTaskCancelEvent,
                       new RoutedEventHandler(DeleteTaskCancelEventHandler));
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
            _addTaskControl = new AddTaskControl();
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
            TaskInfoArgs args = e as TaskInfoArgs;

            _deletionTaskControl = new DeletionTaskControl(args.TaskInfo);
            AddTaskButton.Visibility = Visibility.Hidden;
            MainContentArea.Content = _deletionTaskControl;
        }

        private void TaskCompletedEventFromMainWindowHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            AccessDBManager.UpdateTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());
        }

        private void DeleteTaskConfirmEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            AccessDBManager.DeleteTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());

            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        private void DeleteTaskCancelEventHandler(object sender, RoutedEventArgs e)
        {
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        private void AddTaskConfirmEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            AccessDBManager.InsertTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());

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

            AccessDBManager.UpdateTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());

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
