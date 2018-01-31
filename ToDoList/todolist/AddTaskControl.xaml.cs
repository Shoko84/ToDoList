﻿using System;
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
    /// Interaction logic for AddTaskControl.xaml
    /// </summary>
    public partial class AddTaskControl : UserControl
    {
        // Class variables
        TaskInfo _taskInfo;

        //Events / Signals
        public static readonly RoutedEvent AddTaskConfirmEvent =
            EventManager.RegisterRoutedEvent("AddTaskConfirmEvent", RoutingStrategy.Bubble,
            typeof(TaskInfoArgs), typeof(AddTaskControl));

        public static readonly RoutedEvent AddTaskCancelEvent =
            EventManager.RegisterRoutedEvent("AddTaskCancelEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventArgs), typeof(AddTaskControl));


        // Methods
        public AddTaskControl()
        {
            InitializeComponent();
            _taskInfo = new TaskInfo();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AddTaskControl.AddTaskCancelEvent));
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            _taskInfo.Title = TitleTextBox.Text;
            _taskInfo.Content = ContentTextBox.Text;
            _taskInfo.Due = DueTimePicker.SelectedDate;
            if (!String.IsNullOrWhiteSpace(_taskInfo.Title) && _taskInfo.Due.HasValue)
                RaiseEvent(new TaskInfoArgs(AddTaskControl.AddTaskConfirmEvent, _taskInfo));
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
