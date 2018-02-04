using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace todolist.Tests
{
    [TestClass()]
    public class FilterInfoTests
    {
        [TestMethod()]
        public void FilterInfoTest()
        {
            FilterInfo filterInfo = new FilterInfo(true, false);

            Assert.IsNotNull(filterInfo);
            Assert.AreEqual(filterInfo.ShowTodo, true);
            Assert.AreEqual(filterInfo.ShowDone, false);
        }
    }
}