namespace GBUtils.Test.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GBUtils.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FileFormatter
    {
        [TestMethod]
        public void FilePathFormatter_Format()
        {
            string path = @"c:\temp\readme.txt";
            Assert.AreEqual(@"", FilePathFormatter.Format("", FilePathFormat.Ellipsis));
            Assert.AreEqual(path, FilePathFormatter.Format(path, FilePathFormat.Full));
            Assert.AreEqual(@"c:\...\temp\readme.txt", FilePathFormatter.Format(path, FilePathFormat.Ellipsis));
            Assert.AreEqual(@"c:\temp", FilePathFormatter.Format(path, FilePathFormat.FullDir));
            Assert.AreEqual(@"readme.txt", FilePathFormatter.Format(path, FilePathFormat.Short));
            Assert.AreEqual(@"readme.txt (c:\temp)", FilePathFormatter.Format(path, FilePathFormat.ShortFileFullDir));
        }

    }
}
