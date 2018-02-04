using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace todolist.Tests
{
    [TestClass()]
    public class TaskPanelViewerTests
    {
        [TestMethod()]
        public void TaskPanelViewerTest()
        {
            List<TaskPanel> taskPanels = new List<TaskPanel>();
            Assert.IsNotNull(taskPanels);

            FilterInfo filterInfo = new FilterInfo(true, true);
            Assert.IsNotNull(filterInfo);

            TaskPanelViewer taskPanelViewer = new TaskPanelViewer();
            Assert.IsNotNull(taskPanelViewer);
        }

        [TestMethod()]
        public void AddTaskTest()
        {
            List<TaskPanel> taskPanels = new List<TaskPanel>();
            Assert.IsNotNull(taskPanels);

            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo firstInfo = new TaskInfo(521, "First task", "Some data", timeNow, false);
            TaskInfo secondInfo = new TaskInfo(530, "Second task", "Some other data", timeNow, false);
            TaskInfo thirdInfo = new TaskInfo(985, "Third task", "Again some data", timeNow, false);
            Assert.IsNotNull(firstInfo);
            Assert.IsNotNull(secondInfo);
            Assert.IsNotNull(thirdInfo);

            TaskPanel firstPanel = new TaskPanel(firstInfo);
            TaskPanel secondPanel = new TaskPanel(secondInfo);
            TaskPanel thirdPanel = new TaskPanel(thirdInfo);
            Assert.IsNotNull(firstPanel);
            Assert.IsNotNull(secondPanel);
            Assert.IsNotNull(thirdPanel);

            taskPanels.Add(firstPanel);
            taskPanels.Add(secondPanel);
            taskPanels.Add(thirdPanel);
            Assert.AreEqual(taskPanels.Count, 3);

            TaskInfo infoToAdd = new TaskInfo(999, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(infoToAdd);

            TaskPanel panelToAdd = new TaskPanel(infoToAdd);
            Assert.IsNotNull(panelToAdd);

            taskPanels.Add(panelToAdd);
            Assert.AreEqual(taskPanels.Count, 4);
            Assert.AreEqual(taskPanels[taskPanels.Count - 1].Info, infoToAdd);
        }

        [TestMethod()]
        public void AddTasksTest()
        {
            List<TaskPanel> taskPanels = new List<TaskPanel>();
            Assert.IsNotNull(taskPanels);

            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo firstInfo = new TaskInfo(521, "First task", "Some data", timeNow, false);
            Assert.IsNotNull(firstInfo);

            TaskPanel firstPanel = new TaskPanel(firstInfo);
            Assert.IsNotNull(firstPanel);

            taskPanels.Add(firstPanel);
            Assert.AreEqual(taskPanels.Count, 1);

            TaskInfo infoToAdd1 = new TaskInfo(68, "A task", "Some data", timeNow, false);
            TaskInfo infoToAdd2 = new TaskInfo(69, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(infoToAdd1);
            Assert.IsNotNull(infoToAdd2);

            List<TaskInfo> taskInfosToAdd = new List<TaskInfo>
            {
                infoToAdd1,
                infoToAdd2
            };
            Assert.IsNotNull(taskInfosToAdd);

            for (var i = 0; i < taskInfosToAdd.Count; ++i)
            {
                TaskPanel panelToAdd = new TaskPanel(taskInfosToAdd[i]);
                Assert.IsNotNull(panelToAdd);
                taskPanels.Add(panelToAdd);
                Assert.AreEqual(taskPanels.Count, 1 + i + 1);
                Assert.AreEqual(taskPanels[taskPanels.Count - 1].Info, taskInfosToAdd[i]);
            }
        }

        [TestMethod()]
        public void SetTasksTest()
        {
            List<TaskPanel> taskPanels = new List<TaskPanel>();
            Assert.IsNotNull(taskPanels);

            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo firstInfo = new TaskInfo(521, "First task", "Some data", timeNow, false);
            TaskInfo secondInfo = new TaskInfo(530, "Second task", "Some other data", timeNow, false);
            Assert.IsNotNull(firstInfo);
            Assert.IsNotNull(secondInfo);

            TaskPanel firstPanel = new TaskPanel(firstInfo);
            TaskPanel secondPanel = new TaskPanel(secondInfo);
            Assert.IsNotNull(firstPanel);
            Assert.IsNotNull(secondPanel);

            taskPanels.Add(firstPanel);
            taskPanels.Add(secondPanel);
            Assert.AreEqual(taskPanels.Count, 2);

            taskPanels.Clear();
            Assert.AreEqual(taskPanels.Count, 0);

            TaskInfo thirdInfo = new TaskInfo(18562, "Third task", "Some data", timeNow, false);
            Assert.IsNotNull(thirdInfo);

            TaskPanel thirdPanel = new TaskPanel(thirdInfo);
            Assert.IsNotNull(thirdPanel);

            taskPanels.Add(thirdPanel);
            Assert.AreEqual(taskPanels.Count, 1);
            Assert.AreEqual(taskPanels[0].Info, thirdInfo);
        }

        [TestMethod()]
        public void ApplyFilterTest()
        {
            FilterInfo filterInfo = new FilterInfo(false, false);
            Assert.IsNotNull(filterInfo);

            TaskPanelViewer taskPanelViewer = new TaskPanelViewer();
            Assert.IsNotNull(taskPanelViewer);

            taskPanelViewer.FilterInfo = filterInfo;
            Assert.AreEqual(taskPanelViewer.FilterInfo, filterInfo);
        }
    }
}