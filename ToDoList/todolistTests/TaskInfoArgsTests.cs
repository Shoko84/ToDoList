using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace todolist.Tests
{
    [TestClass()]
    public class TaskInfoArgsTests
    {
        public static readonly RoutedEvent AnEvent =
                   EventManager.RegisterRoutedEvent("AnEvent", RoutingStrategy.Bubble,
                   typeof(TaskInfoArgs), typeof(TaskInfoArgsTests));

        [TestMethod()]
        public void TaskInfoArgsTest()
        {
            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(taskInfo);

            TaskInfoArgs args = new TaskInfoArgs(TaskInfoArgsTests.AnEvent, taskInfo);

            Assert.IsNotNull(args);
            Assert.AreEqual(args.TaskInfo, taskInfo);
        }
    }
}