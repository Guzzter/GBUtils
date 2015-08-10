namespace GBUtils.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test for the StringUtils extension methods
    /// </summary>
    [TestClass]
    public class StringUtils
    {
        [TestMethod]
        public void IsBlank_All()
        {
            Assert.IsFalse("word".IsBlank());
            Assert.IsTrue(string.Empty.IsBlank());
            Assert.IsTrue("".IsBlank());
            Assert.IsTrue(" ".IsBlank());
            Assert.IsTrue("   ".IsBlank());
            string testString = null;
            Assert.IsTrue(testString.IsBlank());
        }

        [TestMethod]
        public void Coalesce_emptyWithModeNull_ShouldReturnFallback()
        {
            var value = "".Coalesce("fallback", StringCoalesceMode.NullOrBlank);
            Assert.AreEqual("fallback", value);

            var value2 = "".Coalesce("fallback");
            Assert.AreEqual("fallback", value2);

        }

        [TestMethod]
        public void Coalesce_whiteSpaceWithModeNullOrBlank_ShouldReturnFallback()
        {
            var value = " ".Coalesce();
            Assert.AreEqual("", value);
        }

        [TestMethod]
        public void Coalesce_whiteSpaceWithModeBlank_ShouldReturnOriginal()
        {
            var value = " ".Coalesce("fallback", StringCoalesceMode.NullOrEmpty);
            Assert.AreEqual(" ", value);
        }

        [TestMethod]
        public void Coalesce_NullSpaceWithModeNull_ShouldReturnFallback()
        {
            string testString = null;
            var value = testString.Coalesce("fallback", StringCoalesceMode.Null);
            Assert.AreEqual("fallback", value);
        }

        [TestMethod]
        public void Coalesce_NullWithModeNullOrEmpty_ShouldReturnFallback()
        {
            string testString = null;
            var value = testString.Coalesce("fallback", StringCoalesceMode.NullOrEmpty);
            Assert.AreEqual("fallback", value);
        }

        [TestMethod]
        public void Coalesce_NullWithModeNullOrBlank_ShouldReturnFallback()
        {
            string testString = null;
            var value = testString.Coalesce("fallback", StringCoalesceMode.NullOrBlank);
            Assert.AreEqual("fallback", value);
        }

        [TestMethod]
        public void Coalesce_NullWithModeNullOrBlank_ShouldReturnOriginal()
        {
            string testString = "good";
            var value = testString.Coalesce("fallback", StringCoalesceMode.NullOrBlank);
            Assert.AreEqual("good", value);
        }
    }

}
