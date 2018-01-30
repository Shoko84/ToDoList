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
using System.Windows.Shapes;

namespace todolist
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
   
    public partial class AddTaskWindow : Window
    {
        private TaskInfo _taskInfo;

        public AddTaskWindow(TaskInfo taskInfo)
        {
            InitializeComponent();
            _taskInfo = taskInfo;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            _taskInfo.Title = TitleTextBox.Text;
            _taskInfo.Content = ContentTextBox.Text;
            _taskInfo.Due = DueTimePicker.SelectedDate;
            Close();
        }
    }
}
