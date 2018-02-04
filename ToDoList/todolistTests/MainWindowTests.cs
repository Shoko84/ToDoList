using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace todolist.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void MainWindowTest()
        {
            TaskPanelViewer taskPanelViewer = new TaskPanelViewer();
            Assert.IsNotNull(taskPanelViewer);
        }
    }
}