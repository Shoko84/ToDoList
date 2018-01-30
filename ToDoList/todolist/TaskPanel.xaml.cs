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
            TextContent.Text = Info.Title + "\r\n\r\n" + Info.Content;
        }

        //Event raising for a communication with the main window

        public static readonly RoutedEvent TaskEditEventFromPanel =
            EventManager.RegisterRoutedEvent("TaskEditEventFromPanel", RoutingStrategy.Bubble,
            typeof(TaskPanelArgs), typeof(TaskPanel));

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new TaskPanelArgs(TaskPanel.TaskEditEventFromPanel, Info));
        }
    }
}
