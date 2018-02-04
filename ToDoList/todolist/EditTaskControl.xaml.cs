using System;
using System.Windows;
using System.Windows.Controls;

namespace todolist
{
    /// <summary>
    /// Interaction logic for EditTaskControl.xaml
    /// </summary>
    public partial class EditTaskControl : UserControl
    {
        /// <summary>
        /// The info's task that will be possibly edited
        /// </summary>
        private TaskInfo _taskInfo;

        /// <summary>
        /// Event raised when the user clicks on the 'Confirm' button
        /// </summary>
        public static readonly RoutedEvent EditTaskConfirmEvent =
            EventManager.RegisterRoutedEvent("EditTaskConfirmEvent", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(EditTaskControl));

        /// <summary>
        /// Event raised when the user clicks on the 'Cancel' button
        /// </summary>
        public static readonly RoutedEvent EditTaskCancelEvent =
            EventManager.RegisterRoutedEvent("EditTaskCancelEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventArgs), typeof(EditTaskControl));

        /// <summary>
        /// Constructor of the <see cref="EditTaskControl"/> class
        /// </summary>
        public EditTaskControl(TaskInfo taskInfo)
        {
            InitializeComponent();

            _taskInfo = taskInfo;
            TitleTextBox.Text = _taskInfo.Title;
            ContentTextBox.Text = _taskInfo.Content;
            DueTimePicker.SelectedDate = _taskInfo.Due;
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            DueTimePicker.BlackoutDates.Add(cdr);
        }

        /// <summary>
        /// Function triggered when the 'Cancel' button is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(EditTaskControl.EditTaskCancelEvent));
        }

        /// <summary>
        /// Function triggered when the 'Confirm' button is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            _taskInfo.Title = TitleTextBox.Text;
            _taskInfo.Content = ContentTextBox.Text;
            _taskInfo.Due = DueTimePicker.SelectedDate;
            if (!String.IsNullOrWhiteSpace(_taskInfo.Title) && _taskInfo.Due.HasValue)
                RaiseEvent(new TaskInfoArgs(EditTaskControl.EditTaskConfirmEvent, _taskInfo));
            else
            {
                if (String.IsNullOrWhiteSpace(_taskInfo.Title))
                    MessageBox.Show("Please enter a task title", "Empty title", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else if (!_taskInfo.Due.HasValue)
                    MessageBox.Show("Please enter a valid due date", "Invalid due date", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
