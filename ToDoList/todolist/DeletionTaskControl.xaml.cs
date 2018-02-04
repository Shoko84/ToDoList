using System.Windows;
using System.Windows.Controls;

namespace todolist
{
    /// <summary>
    /// Interaction logic for DeletionTaskControl.xaml
    /// </summary>
    public partial class DeletionTaskControl : UserControl
    {
        /// <summary>
        /// The info's task that will be possibly deleted
        /// </summary>
        private TaskInfo _taskInfo;

        /// <summary>
        /// Event raised when the user clicks on the 'Confirm' button
        /// </summary>
        public static readonly RoutedEvent DeleteTaskConfirmEvent =
            EventManager.RegisterRoutedEvent("DeleteTaskConfirmEvent", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(EditTaskControl));

        /// <summary>
        /// Event raised when the user clicks on the 'Cancel' button
        /// </summary>
        public static readonly RoutedEvent DeleteTaskCancelEvent =
            EventManager.RegisterRoutedEvent("DeleteTaskCancelEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventArgs), typeof(EditTaskControl));

        /// <summary>
        /// Constructor of the <see cref="DeletionTaskControl"/> class
        /// </summary>
        public DeletionTaskControl(TaskInfo taskInfo)
        {
            InitializeComponent();
            _taskInfo = taskInfo;
            TaskPanelContent.Content = new TaskPanel(taskInfo);

            TaskPanel taskPanel = TaskPanelContent.Content as TaskPanel;
            taskPanel.DeleteIcon.Visibility = Visibility.Hidden;
            taskPanel.DoneButton.Visibility = Visibility.Hidden;
            taskPanel.IsBlocking = true;
            taskPanel.CanHover =  false;
        }

        /// <summary>
        /// Function triggered when the 'Cancel' button is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DeletionTaskControl.DeleteTaskCancelEvent));
        }

        /// <summary>
        /// Function triggered when the 'Confirm' button is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new TaskInfoArgs(DeletionTaskControl.DeleteTaskConfirmEvent, _taskInfo));
        }
    }
}
