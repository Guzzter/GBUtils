using FluentAssertions;
using Xunit;
using GBUtils.Extension;

namespace GBUtils.Test.Extension
{
    public class WhenUsingBoolExtension
    {
        [Fact]
        public void Given_False_Expect_ToIntToBeZero()
        {
            //Assert.
            false.ToInt().Should().Be(0);
        }

        [Fact]
        public void Given_True_Expect_ToIntToBeOne()
        {
            //Assert.
            true.ToInt().Should().Be(1);
        }
    }
}