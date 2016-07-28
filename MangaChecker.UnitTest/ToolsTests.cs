using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MangaChecker.Utility.Tests
{
    [TestClass]
    public class ToolsTests
    {
        [TestMethod]
        public void GetFeedTest()
        {
            var yee = Tools.GetFeed("http://mangastream.com/rss", "Mangastream");
            Assert.IsNotNull(yee);
        }
    }
}