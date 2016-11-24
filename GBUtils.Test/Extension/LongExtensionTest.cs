using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GBUtils.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GBUtils.Test.Extension
{
    [TestClass]
    public class LongExtensionTest
    {
        [TestMethod]
        public void TestFormatBytesAsHumanReabable()
        {
            long size = (1024*1024);
            Assert.AreEqual("1 MB", size.FormatBytes());
            size = (1024 * 1024 * 1024 - 1);
            Assert.AreEqual("1024 MB", size.FormatBytes()); 
            size = (1024 * 1024 + 600000);
            Assert.AreEqual("1.57 MB", size.FormatBytes());
        }
    }
}
