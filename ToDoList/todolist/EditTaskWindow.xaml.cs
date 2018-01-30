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
    /// Interaction logic for EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        private TaskInfo _taskInfo;

        public EditTaskWindow(TaskInfo taskInfo)
        {
            InitializeComponent();
            _taskInfo = taskInfo;

            TitleTextBox.Text = _taskInfo.Title;
            ContentTextBox.Text = _taskInfo.Content;
            DueTimePicker.SelectedDate = _taskInfo.Due;
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
