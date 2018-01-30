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
        List<TaskPanel> taskPanels;

        public MainWindow()
        {
            InitializeComponent();
            taskPanels = new List<TaskPanel>();
        }

        private void RefreshTaskPanelsOnScreen()
        {
            TaskPanelsContainer.Children.Clear();
            for (var i = 0; i < taskPanels.Count; ++i)
                TaskPanelsContainer.Children.Add(taskPanels[i]);
        }

        private void AddTaskButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TaskInfo taskInfo = new TaskInfo();

            _addTaskWindow = new AddTaskWindow(taskInfo);
            if (_addTaskWindow.ShowDialog() ?? false)
            {
                Console.WriteLine(taskInfo.Title);
                Console.WriteLine(taskInfo.Content);
                Console.WriteLine(taskInfo.Due.ToString());
                taskPanels.Add(new TaskPanel(taskInfo));
                RefreshTaskPanelsOnScreen();
            }
        }
    }
}
