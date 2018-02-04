using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace todolist.Tests
{
    [TestClass()]
    public class AddTaskControlTests
    {
        [TestMethod()]
        public void AddTaskControlTest()
        {
            AddTaskControl addTaskControl = new AddTaskControl();

            Assert.IsNotNull(addTaskControl);
        }
    }
}