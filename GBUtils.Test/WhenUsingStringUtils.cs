using System;
using Xunit;
using FluentAssertions;

namespace GBUtils.Test
{
    public class WhenUsingStringUtils
    {
        [Fact]
        public void Coalesce_emptyWithModeNull_ShouldReturnFallback()
        {
            var value = "".Coalesce("fallback", StringCoalesceMode.NullOrBlank);
            Assert.Equal("fallback", value);

            var value2 = "".Coalesce("fallback");
            Assert.Equal("fallback", value2);
        }

        [Fact]
        public void Coalesce_NullSpaceWithModeNull_ShouldReturnFallback()
        {
            string testString = null;
            var value = testString.Coalesce("fallback", StringCoalesceMode.Null);
            Assert.Equal("fallback", value);
        }

        [Fact]
        public void Coalesce_NullWithModeNullOrBlank_ShouldReturnFallback()
        {
            string testString = null;
            var value = testString.Coalesce("fallback", StringCoalesceMode.NullOrBlank);
            Assert.Equal("fallback", value);
        }

        [Fact]
        public void Coalesce_NullWithModeNullOrBlank_ShouldReturnOriginal()
        {
            string testString = "good";
            var value = testString.Coalesce("fallback", StringCoalesceMode.NullOrBlank);
            Assert.Equal("good", value);
        }

        [Fact]
        public void Coalesce_NullWithModeNullOrEmpty_ShouldReturnFallback()
        {
            string testString = null;
            var value = testString.Coalesce("fallback", StringCoalesceMode.NullOrEmpty);
            Assert.Equal("fallback", value);
        }

        [Fact]
        public void Coalesce_whiteSpaceWithModeBlank_ShouldReturnOriginal()
        {
            var value = " ".Coalesce("fallback", StringCoalesceMode.NullOrEmpty);
            Assert.Equal(" ", value);
        }

        [Fact]
        public void Coalesce_whiteSpaceWithModeNullOrBlank_ShouldReturnFallback()
        {
            var value = " ".Coalesce();
            Assert.Equal("", value);
        }

        [Fact]
        public void IsBlank_All()
        {
            "word".IsBlank().Should().BeFalse();
            "".IsBlank().Should().BeTrue();
            " ".IsBlank().Should().BeTrue();
            "   ".IsBlank().Should().BeTrue();

            string testString = null;
            testString.IsBlank().Should().BeTrue();
        }
    }
}