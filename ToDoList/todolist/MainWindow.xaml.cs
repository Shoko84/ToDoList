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
        AddTaskWindow _addTaskWindow;
        EditTaskWindow _editTaskWindow;
        TaskPanelViewer _taskPanelViewer;

        public MainWindow()
        {
            InitializeComponent();
            _taskPanelViewer = new TaskPanelViewer();
            MainContentArea.Content = _taskPanelViewer;

            AddHandler(TaskPanelViewer.TaskEditEventFromPanelViewer,
                       new RoutedEventHandler(TaskEditEventFromMainWindowHandler));
        }

        private void TaskEditEventFromMainWindowHandler(object sender, RoutedEventArgs e)
        {
            TaskPanelArgs args = e as TaskPanelArgs;
            Console.WriteLine(args.TaskInfo.Id);

            _editTaskWindow = new EditTaskWindow(args.TaskInfo);
            if (_editTaskWindow.ShowDialog() ?? false)
            {
                Console.WriteLine(args.TaskInfo.Title);
                Console.WriteLine(args.TaskInfo.Content);
                Console.WriteLine(args.TaskInfo.Due.ToString());
                _taskPanelViewer.EditTask(args.TaskInfo);
            }
        }

        private void AddTaskButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TaskInfo taskInfo = new TaskInfo(Convert.ToUInt32(_taskPanelViewer.TaskPanels.Count));

            _addTaskWindow = new AddTaskWindow(taskInfo);
            if (_addTaskWindow.ShowDialog() ?? false)
            {
                Console.WriteLine(taskInfo.Title);
                Console.WriteLine(taskInfo.Content);
                Console.WriteLine(taskInfo.Due.ToString());
                _taskPanelViewer.AddTask(taskInfo);
            }
        }
    }
}
