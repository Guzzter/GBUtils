using FluentAssertions;
using Xunit;
using GBUtils.Extension;

namespace GBUtils.Test.Extension
{
    public class WhenUsingCharExtension
    {
        [Fact]
        public void Given_TrueLikeChar_Expect_TrueBooleanValue()
        {
            '1'.ToBool().Should().Be(true);
            'j'.ToBool().Should().Be(true);
            'y'.ToBool().Should().Be(true);
            'J'.ToBool().Should().Be(true);
            'Y'.ToBool().Should().Be(true);
            '+'.ToBool().Should().Be(true);
        }
    }
}