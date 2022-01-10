using FluentAssertions;
using System;
using Xunit;

namespace GBUtils.Test
{
    public class WhenUsingEnumHelper
    {
        public enum TestEnum
        {
            None,
            Medium,
            High
        }

        [Fact]
        public void Parse_ShouldReturnInValidEnum()
        {
            //Act
            Action act = () => EnumHelper<TestEnum>.Parse("none", false);

            //Assert Exception
            act.Should().Throw<ArgumentException>()
                .WithMessage("Requested value 'none' was not found.");
        }

        [Fact]
        public void Parse_ShouldReturnValidEnum()
        {
            var value = EnumHelper<TestEnum>.Parse("None");
            Assert.Equal(TestEnum.None, value);
            value = EnumHelper<TestEnum>.Parse("none");
            Assert.Equal(TestEnum.None, value);
        }

        [Fact]
        public void TryParse_ShouldReturnFalseWhenIncorrectCase()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("high", false, out em);
            Assert.False(isValid);
            Assert.Equal(TestEnum.None, em);
        }

        [Fact]
        public void TryParse_ShouldReturnFalseWhenUnparseable()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("UltraHigh", out em);
            Assert.False(isValid);
            Assert.Equal(TestEnum.None, em);
        }

        [Fact]
        public void TryParse_ShouldReturnTrueWhenCaseIsUnimportant()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("HiGh", true, out em);
            Assert.True(isValid);
            Assert.Equal(TestEnum.High, em);
        }

        [Fact]
        public void TryParse_ShouldReturnTrueWhenCorrectCase()
        {
            TestEnum em;
            bool isValid = EnumHelper<TestEnum>.TryParse("High", false, out em);
            Assert.True(isValid);
            Assert.Equal(TestEnum.High, em);
        }
    }
}