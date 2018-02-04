using System.Windows;
using System.Windows.Input;

namespace todolist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Manage <see cref="TaskPanel"/> and display these
        /// </summary>
        TaskPanelViewer     _taskPanelViewer;
        /// <summary>
        /// <see cref="UserControl"/> that handles task addition
        /// </summary>
        AddTaskControl      _addTaskControl;
        /// <summary>
        /// <see cref="UserControl"/> that handles task edition
        /// </summary>
        EditTaskControl _editTaskControl;
        /// <summary>
        /// <see cref="UserControl"/> that handles task deletion
        /// </summary>
        DeletionTaskControl _deletionTaskControl;


        /// <summary>
        /// Constructor of the <see cref="MainWindow"/> class
        /// </summary>
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

        /// <summary>
        /// Function triggered when the '+' button is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="MouseButtonEventArgs"/> events</param>
        private void AddTaskButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _addTaskControl = new AddTaskControl();
            AddTaskButton.Visibility = Visibility.Hidden;
            MainContentArea.Content = _addTaskControl;
        }

        /// <summary>
        /// Function triggered when the panel body is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void TaskEditEventFromMainWindowHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            _editTaskControl = new EditTaskControl(args.TaskInfo);
            AddTaskButton.Visibility = Visibility.Hidden;
            MainContentArea.Content = _editTaskControl;
        }

        /// <summary>
        /// Function triggered when the 'Trash' icon on the panel is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void TaskDeleteEventFromMainWindowHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            _deletionTaskControl = new DeletionTaskControl(args.TaskInfo);
            AddTaskButton.Visibility = Visibility.Hidden;
            MainContentArea.Content = _deletionTaskControl;
        }

        /// <summary>
        /// Function triggered when the user clicked on the 'Done' button inside a task panel
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void TaskCompletedEventFromMainWindowHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            AccessDBManager.UpdateTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());
        }

        /// <summary>
        /// Function triggered when the 'Confirm' button is clicked on the <see cref="DeletionTaskControl"/>
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DeleteTaskConfirmEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            AccessDBManager.DeleteTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());

            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        /// <summary>
        /// Function triggered when the 'Cancel' button is clicked on the <see cref="DeletionTaskControl"/>
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DeleteTaskCancelEventHandler(object sender, RoutedEventArgs e)
        {
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        /// <summary>
        /// Function triggered when the 'Confirm' button is clicked on the <see cref="AddTaskControl"/>
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void AddTaskConfirmEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            AccessDBManager.InsertTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());

            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        /// <summary>
        /// Function triggered when the 'Cancel' button is clicked on the <see cref="AddTaskControl"/>
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void AddTaskCancelEventHandler(object sender, RoutedEventArgs e)
        {
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        /// <summary>
        /// Function triggered when the 'Confirm' button is clicked on the <see cref="EditTaskControl"/>
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void EditTaskConfirmEventHandler(object sender, RoutedEventArgs e)
        {
            TaskInfoArgs args = e as TaskInfoArgs;

            AccessDBManager.UpdateTaskInDB(args.TaskInfo);

            //Update from the DB
            _taskPanelViewer.SetTasks(AccessDBManager.FindTasksFromDB());

            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        /// <summary>
        /// Function triggered when the 'Cancel' button is clicked on the <see cref="EditTaskControl"/>
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void EditTaskCancelEventHandler(object sender, RoutedEventArgs e)
        {
            AddTaskButton.Visibility = Visibility.Visible;
            MainContentArea.Content = _taskPanelViewer;
        }

        /// <summary>
        /// Function triggered when the checkbox state of a filter has changed
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void FilterParametersChanged(object sender, RoutedEventArgs e)
        {
            if (_taskPanelViewer != null && TodoFilterCheckbox != null && CompletedFilterCheckbox != null)
                _taskPanelViewer.ApplyFilter(new FilterInfo(TodoFilterCheckbox.IsChecked ?? false, CompletedFilterCheckbox.IsChecked ?? false));
        }

        private void ShowAllFilters_Click(object sender, RoutedEventArgs e)
        {
            TodoFilterCheckbox.IsChecked = true;
            CompletedFilterCheckbox.IsChecked = true;
        }

        private void ClearAllFilters_Click(object sender, RoutedEventArgs e)
        {
            TodoFilterCheckbox.IsChecked = false;
            CompletedFilterCheckbox.IsChecked = false;
        }
    }
}
