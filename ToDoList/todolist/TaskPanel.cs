using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace todolist
{
    public class TaskPanel : Button
    {
        public TaskInfo Info { get; set; }
        private TextBlock _textContent;

        public TaskPanel(TaskInfo taskInfo)
        {
            Info = taskInfo;

            _textContent = new TextBlock();
            _textContent.TextWrapping = System.Windows.TextWrapping.Wrap;
            _textContent.Text = Info.Title + "\r\n\r\n" + Info.Content;
            _textContent.Height = Double.NaN;
            AddChild(_textContent);

            Width = 120;
            Height = 160;
            HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            VerticalContentAlignment = System.Windows.VerticalAlignment.Top;
            Margin = new System.Windows.Thickness(15);
            
        }
    }
}
