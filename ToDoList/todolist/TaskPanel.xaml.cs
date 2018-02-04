using FontAwesome.WPF;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace todolist
{
    /// <summary>
    /// Interaction logic for TaskPanel.xaml
    /// </summary>
    public partial class TaskPanel : UserControl
    {
        /// <summary>
        /// The task informations
        /// </summary>
        public TaskInfo Info { get; set; }
        /// <summary>
        /// Are events blocked ?
        /// </summary>
        public bool    IsBlocking { get; set; }
        /// <summary>
        /// Are panels changing colors when hovering ?
        /// </summary>
        public bool    CanHover { get; set; }

        /// <summary>
        /// Constructor of the <see cref="TaskPanel"/> class
        /// </summary>
        /// <param name="taskInfo">The task informations to be filled in the panel</param>
        public TaskPanel(TaskInfo taskInfo)
        {
            InitializeComponent();
            Info = taskInfo;
            TextTitle.Text = Info.Title;
            TextContent.Text = Info.Content;
            IsBlocking = false;
            CanHover = true;

            // Status of a Task
            Image img = new Image
            {
                Width = 10,
                Height = 10
            };
            if (Info.Completed)
            {
                img.Source = ImageAwesome.CreateImageSource(FontAwesomeIcon.Check, Brushes.White);
                DoneButton.Visibility = Visibility.Hidden;
            }
            else
                img.Source = ImageAwesome.CreateImageSource(FontAwesomeIcon.Times, Brushes.White);
            Grid.SetColumn(TopInnerGrid, 0);
            img.VerticalAlignment = VerticalAlignment.Top;
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.Margin = new Thickness(5,5,0,0);
            TaskGrid.Children.Add(img);
        }

        //Event raising for a communication with the main window

        /// <summary>
        /// Event raised when the user clicks the panel body
        /// </summary>
        public static readonly RoutedEvent TaskEditEventFromPanel =
            EventManager.RegisterRoutedEvent("TaskEditEventFromPanel", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanel));

        /// <summary>
        /// Event raised when the user clicks the 'Trash' icon at the top right corner
        /// </summary>
        public static readonly RoutedEvent TaskDeleteEventFromPanel =
            EventManager.RegisterRoutedEvent("TaskDeleteEventFromPanel", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanel));

        /// <summary>
        /// Event raised when the user clicks the 'Done' button
        /// </summary>
        public static readonly RoutedEvent TaskCompletedEventFromPanel =
            EventManager.RegisterRoutedEvent("TaskCompletedEventFromPanel", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanel));

        /// <summary>
        /// Function triggered when the panel body is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void EditTaskClick(object sender, MouseButtonEventArgs e)
        {
            if (!IsBlocking)
                RaiseEvent(new TaskInfoArgs(TaskPanel.TaskEditEventFromPanel, Info));
        }

        /// <summary>
        /// Function triggered when the panel body is hovered
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void HoveringEnterTask(object sender, MouseEventArgs e)
        {
            if (CanHover)
                TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4286b2"));
        }

        /// <summary>
        /// Function triggered when the mouse cursor is leaving the panel body
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void HoveringLeaveTask(object sender, MouseEventArgs e)
        {
            if (CanHover)
                TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e81b7"));
        }

        /// <summary>
        /// Function triggered when the 'Trash' icon is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DeleteIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            if (!IsBlocking)
                RaiseEvent(new TaskInfoArgs(TaskPanel.TaskDeleteEventFromPanel, Info));
        }

        /// <summary>
        /// Function triggered when the 'Trash' icon is hovered
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DeleteIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CanHover)
                TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e81b7"));
            e.Handled = true;
        }

        /// <summary>
        /// Function triggered when the mouse cursor is leaving the 'Trash' icon
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DeleteIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CanHover)
                TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4286b2"));
            e.Handled = true;
        }

        /// <summary>
        /// Function triggered when the 'Done' button is clicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Info.Completed = true;
            if (!IsBlocking)
                RaiseEvent(new TaskInfoArgs(TaskPanel.TaskCompletedEventFromPanel, Info));
        }

        /// <summary>
        /// Function triggered when the 'Done' button is hovered
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DoneButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CanHover)
                TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e81b7"));
            e.Handled = true;
        }

        /// <summary>
        /// Function triggered when the mouse cursor is leaving the 'Done' button
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The sender <see cref="RoutedEventArgs"/> events</param>
        private void DoneButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CanHover)
                TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4286b2"));
            e.Handled = true;
        }
    }
}
