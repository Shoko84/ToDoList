using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace todolist.Tests
{
    [TestClass()]
    public class TaskInfoTests
    {
        [TestMethod()]
        public void TaskInfoTest()
        {
            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A task", "Some data", timeNow, false);

            Assert.IsNotNull(taskInfo);
            Assert.AreEqual(taskInfo.Id, 0u);
            Assert.AreEqual(taskInfo.Title, "A task");
            Assert.AreEqual(taskInfo.Content, "Some data");
            Assert.AreEqual(taskInfo.Due, timeNow);
            Assert.AreEqual(taskInfo.Completed, false);
        }
    }
}