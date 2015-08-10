
namespace GBUtils.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class EnumHelper
    {
        public enum TestEnum
        {
            None, 
            Medium, 
            High
        }

        [TestMethod]
        public void Parse_ShouldReturnValidEnum()
        {
            var value = EnumHelper<TestEnum>.Parse("None");
            Assert.AreEqual(TestEnum.None, value);
            value = EnumHelper<TestEnum>.Parse("none");
            Assert.AreEqual(TestEnum.None, value);
        }

        [TestMethod]
        public void Parse_ShouldReturnInValidEnum()
        {
            var ex = ExceptionAssert.Throws<ArgumentException>(() => EnumHelper<TestEnum>.Parse("none", false));
            Assert.AreEqual("Requested value 'none' was not found.", ex.Message);
        }

        [TestMethod]
        public void TryParse_ShouldReturnFalseWhenUnparseable()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("UltraHigh", out em);
            Assert.IsFalse(isValid);
            Assert.AreEqual(TestEnum.None, em);
        }

        [TestMethod]
        public void TryParse_ShouldReturnFalseWhenIncorrectCase()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("high", false, out em);
            Assert.IsFalse(isValid);
            Assert.AreEqual(TestEnum.None, em);
        }

        [TestMethod]
        public void TryParse_ShouldReturnTrueWhenCorrectCase()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("High", false, out em);
            Assert.IsTrue(isValid);
            Assert.AreEqual(TestEnum.High, em);
        }

        [TestMethod]
        public void TryParse_ShouldReturnTrueWhenCaseIsUnimportant()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("HiGh", true, out em);
            Assert.IsTrue(isValid);
            Assert.AreEqual(TestEnum.High, em);
        }
    }
}
