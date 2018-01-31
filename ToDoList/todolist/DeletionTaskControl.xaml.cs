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
    /// Interaction logic for DeletionTaskControl.xaml
    /// </summary>
    public partial class DeletionTaskControl : UserControl
    {
        private TaskInfo _taskInfo;

        //Events / Signals
        public static readonly RoutedEvent DeleteTaskConfirmEvent =
            EventManager.RegisterRoutedEvent("DeleteTaskConfirmEvent", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(EditTaskControl));

        public static readonly RoutedEvent DeleteTaskCancelEvent =
            EventManager.RegisterRoutedEvent("DeleteTaskCancelEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventArgs), typeof(EditTaskControl));

        public DeletionTaskControl(TaskInfo taskInfo)
        {
            InitializeComponent();
            _taskInfo = taskInfo;
            TaskPanelContent.Content = new TaskPanel(taskInfo);

            TaskPanel taskPanel = TaskPanelContent.Content as TaskPanel;
            taskPanel.DeleteIcon.Visibility = Visibility.Hidden;
            taskPanel.DoneButton.Visibility = Visibility.Hidden;
            taskPanel.BlockingEventRaising(true);
            taskPanel.EnableHovering(false);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DeletionTaskControl.DeleteTaskCancelEvent));
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new TaskInfoArgs(DeletionTaskControl.DeleteTaskConfirmEvent, _taskInfo));
        }
    }
}
