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
        }

        //Event raising for a communication with the main window

        public static readonly RoutedEvent TaskEditEventFromPanel =
            EventManager.RegisterRoutedEvent("TaskEditEventFromPanel", RoutingStrategy.Bubble,
            typeof(TaskPanelArgs), typeof(TaskPanel));

        private void EditTaskClick(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new TaskPanelArgs(TaskPanel.TaskEditEventFromPanel, Info));
        }

        private void HoveringEnterTask(object sender, MouseEventArgs e)
        {
            TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4286b2"));
        }

        private void HoveringLeaveTask(object sender, MouseEventArgs e)
        {
            TaskGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e81b7"));
        }
    }
}
