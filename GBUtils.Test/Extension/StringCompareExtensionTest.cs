namespace GBUtils.Test.Extension
{
    using GBUtils.Extension;
    using GBUtils.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringCompareExtensionTest
    {
        [TestMethod]
        public void TestEqualsIc()
        {
            Assert.IsTrue("DUMMY".EqualsIc("DuMMy"));
            Assert.IsFalse("DUMMY".EqualsIc(""));
            Assert.IsFalse("DUMMY".EqualsIc(null));
        }

        [TestMethod]
        public void TestContainsOneOf()
        {
            Assert.IsFalse("DUMMY".ContainsOneOf("Bla", "DuMMy"));
            Assert.IsTrue("DUMMY".ContainsOneOf("Foo", "Bar", "DUMMY"));
            Assert.IsFalse("DUMMY".ContainsOneOf(null));
        }

        [TestMethod]
        public void TestContainsOneOfIc()
        {
            Assert.IsTrue("DUMMY".ContainsOneOfIc("Bla", "DuMMy"));
            Assert.IsFalse("DUMMY".ContainsOneOfIc("Foo", "Bar"));
            Assert.IsFalse("DUMMY".ContainsOneOfIc(null));
        }

        [TestMethod]
        public void TestStartsWithIc()
        {
            Assert.IsTrue("DUMMY".StartsWithIc("DuM"));
            Assert.IsFalse("DUMMY".StartsWithIc(""));
            Assert.IsFalse("DUMMY".StartsWithIc(null));
        }

        [TestMethod]
        public void TestIn()
        {
            Assert.IsFalse("DUMMY".In("DuMMy", "bla"));
            Assert.IsTrue("DUMMY".In("bla", "DUMMY"));
            Assert.IsFalse("DUMMY".In(""));
            Assert.IsFalse("DUMMY".In(null));
        }


    }
}
