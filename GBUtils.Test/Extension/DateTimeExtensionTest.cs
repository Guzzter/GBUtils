namespace GBUtils.Test.Extension
{
    using System;
    using GBUtils.Extension;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateTimeExtensionTest
    {
        [TestMethod]
        public void TestDayOfWeek()
        {
            DateTime dt = new DateTime(2014, 3, 13); //current date somewhere in a week
            Assert.AreEqual(new DateTime(2014, 3, 10), dt.LookupDateOfWeek(DayOfWeek.Monday));
            Assert.AreEqual(new DateTime(2014, 3, 11), dt.LookupDateOfWeek(DayOfWeek.Tuesday));
            Assert.AreEqual(new DateTime(2014, 3, 12), dt.LookupDateOfWeek(DayOfWeek.Wednesday));
            Assert.AreEqual(new DateTime(2014, 3, 13), dt.LookupDateOfWeek(DayOfWeek.Thursday));
            Assert.AreEqual(new DateTime(2014, 3, 14), dt.LookupDateOfWeek(DayOfWeek.Friday));
            Assert.AreEqual(new DateTime(2014, 3, 15), dt.LookupDateOfWeek(DayOfWeek.Saturday));
            Assert.AreEqual(new DateTime(2014, 3, 16), dt.LookupDateOfWeek(DayOfWeek.Sunday));

            dt = new DateTime(2014, 3, 10);
            Assert.AreEqual(new DateTime(2014, 3, 10), dt.LookupDateOfWeek(DayOfWeek.Monday));

            dt = new DateTime(2014, 3, 16);
            Assert.AreEqual(new DateTime(2014, 3, 16), dt.LookupDateOfWeek(DayOfWeek.Sunday));
        }

        [TestMethod]
        public void TestStartOfWeek()
        {
            DateTime dt = new DateTime(2014, 3, 13); 
            Assert.AreEqual(new DateTime(2014, 3, 10), dt.StartOfWeek(DayOfWeek.Monday));
            Assert.AreEqual(new DateTime(2014, 3, 9), dt.StartOfWeek(DayOfWeek.Sunday));
        }
    }
}
