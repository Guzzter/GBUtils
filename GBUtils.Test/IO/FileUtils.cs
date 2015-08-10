namespace GBUtils.Test.IO
{
    using GBUtils.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FileUtils
    {
        [TestMethod]
        public void StripExtension()
        {
            Assert.AreEqual("readme", "readme.txt".StripExtension());
            Assert.AreEqual("readme.config", "readme.config.txt".StripExtension());
        }
    }
}
