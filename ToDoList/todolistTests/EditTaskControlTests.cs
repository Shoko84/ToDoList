using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace todolist.Tests
{
    [TestClass()]
    public class EditTaskControlTests
    {
        [TestMethod()]
        public void EditTaskControlTest()
        {
            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(taskInfo);

            EditTaskControl editTaskControl = new EditTaskControl(taskInfo);

            Assert.IsNotNull(editTaskControl);
        }
    }
}