using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace todolist.Tests
{
    [TestClass()]
    public class DeletionTaskControlTests
    {
        [TestMethod()]
        public void DeletionTaskControlTest()
        {
            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(taskInfo);

            DeletionTaskControl deleteTaskControl = new DeletionTaskControl(taskInfo);

            Assert.IsNotNull(deleteTaskControl);
        }
    }
}