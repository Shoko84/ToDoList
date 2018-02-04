using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace todolist.Tests
{
    [TestClass()]
    public class TaskPanelTests
    {
        [TestMethod()]
        public void TaskPanelTest()
        {
            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(taskInfo);

            TaskPanel panel = new TaskPanel(taskInfo);

            Assert.IsNotNull(panel);
            Assert.AreEqual(panel.Info, taskInfo);
        }
    }
}