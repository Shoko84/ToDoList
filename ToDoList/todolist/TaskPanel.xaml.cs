using FontAwesome.WPF;
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
    /// Interaction logic for TaskPanel.xaml
    /// </summary>
    public partial class TaskPanel : UserControl
    {
        public TaskInfo Info { get; set; }

        public TaskPanel(TaskInfo taskInfo)
        {
            InitializeComponent();
            Info = taskInfo;
            TextTitle.Text = Info.Title;
            TextContent.Text = Info.Content;

            // Status of a Task
            Image img = new Image
            {
                Width = 10,
                Height = 10
            };
            if (Info.Completed)
                img.Source = ImageAwesome.CreateImageSource(FontAwesomeIcon.Check, Brushes.White);
            else
                img.Source = ImageAwesome.CreateImageSource(FontAwesomeIcon.Times, Brushes.White);
            Grid.SetColumn(TopInnerGrid, 0);
            img.VerticalAlignment = VerticalAlignment.Top;
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.Margin = new Thickness(5,5,0,0);
            TaskGrid.Children.Add(img);
        }

        //Event raising for a communication with the main window

        public static readonly RoutedEvent TaskEditEventFromPanel =
            EventManager.RegisterRoutedEvent("TaskEditEventFromPanel", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanel));

        public static readonly RoutedEvent TaskDeleteEventFromPanel =
            EventManager.RegisterRoutedEvent("TaskDeleteEventFromPanel", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(TaskPanel));

        private void EditTaskClick(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new TaskInfoArgs(TaskPanel.TaskEditEventFromPanel, Info));
        }

        private void HoveringEnterTask(object sender, MouseEventArgs e)
        {
            TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4286b2"));
        }

        private void HoveringLeaveTask(object sender, MouseEventArgs e)
        {
            TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e81b7"));
        }

        private void DeleteIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            RaiseEvent(new TaskInfoArgs(TaskPanel.TaskDeleteEventFromPanel, Info));
        }

        private void DeleteIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e81b7"));
            e.Handled = true;
        }
    }
}
