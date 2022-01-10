using FluentAssertions;
using GBUtils.Extension;
using System;
using Xunit;

namespace GBUtils.Test.Extension
{
    public class WhenUsingDateTimeExtension
    {
        [Fact]
        public void LookupDateOfWeek_Should_ReturnDayOfWeek()
        {
            DateTime dt = new DateTime(2014, 3, 13); //current date somewhere in a week
            Assert.Equal(new DateTime(2014, 3, 10), dt.LookupDateOfWeek(DayOfWeek.Monday));
            Assert.Equal(new DateTime(2014, 3, 11), dt.LookupDateOfWeek(DayOfWeek.Tuesday));
            Assert.Equal(new DateTime(2014, 3, 12), dt.LookupDateOfWeek(DayOfWeek.Wednesday));
            Assert.Equal(new DateTime(2014, 3, 13), dt.LookupDateOfWeek(DayOfWeek.Thursday));
            Assert.Equal(new DateTime(2014, 3, 14), dt.LookupDateOfWeek(DayOfWeek.Friday));
            Assert.Equal(new DateTime(2014, 3, 15), dt.LookupDateOfWeek(DayOfWeek.Saturday));
            Assert.Equal(new DateTime(2014, 3, 16), dt.LookupDateOfWeek(DayOfWeek.Sunday));

            dt = new DateTime(2014, 3, 10);
            Assert.Equal(new DateTime(2014, 3, 10), dt.LookupDateOfWeek(DayOfWeek.Monday));

            dt = new DateTime(2014, 3, 16);
            Assert.Equal(new DateTime(2014, 3, 16), dt.LookupDateOfWeek(DayOfWeek.Sunday));
        }

        [Fact]
        public void StartOfWeek()
        {
            DateTime dt = new DateTime(2014, 3, 13);
            Assert.Equal(new DateTime(2014, 3, 10), dt.StartOfWeek(DayOfWeek.Monday));
            Assert.Equal(new DateTime(2014, 3, 9), dt.StartOfWeek(DayOfWeek.Sunday));

            DateTime dt2 = new DateTime(2016, 5, 1);
            Assert.Equal(new DateTime(2016, 4, 30), dt2.StartOfWeek(DayOfWeek.Saturday));
        }
    }
}