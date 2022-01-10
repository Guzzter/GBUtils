using System;
using Xunit;
using GBUtils.Extension;
using FluentAssertions;

namespace GBUtils.Test.Extension
{
    public class WhenUsingStringExtension
    {
        [Fact]
        public void FirstCharacterUppercase()
        {
            // Arrange
            string source = "thisIsCamelCased";
            string expected = "ThisIsCamelCased";

            // Act
            string target = source.FirstCharacterUppercase();

            // Assert
            Assert.Equal(expected, target);
        }

        [Fact]
        public void FirstCharacterUppercaseRestLowercase()
        {
            // Arrange
            string source = "ThisIsCamelCased";
            string expected = "Thisiscamelcased";

            // Act
            string target = source.FirstCharacterUppercaseRestLowercase();

            // Assert
            Assert.Equal(expected, target);
        }

        [Fact]
        public void FirstCharacterUppercaseWithIJ()
        {
            // Arrange
            string source = "ijskraam";
            string expected = "IJskraam";

            // Act
            string target = source.FirstCharacterUppercase();

            // Assert
            Assert.Equal(expected, target);
        }

        [Fact]
        public void Given_NormalSentence_Expect_EveryWordStartingWithUppercase()
        {
            //Assert.
            "This is a sentence".ToTitleCase().Should().Be("This Is A Sentence");
        }

        [Fact]
        public void Left()
        {
            Assert.Equal("Hey", "Hey Dude".Left(3));
            Assert.Equal("Hey Dude", "Hey Dude".Left(300));
        }

        [Fact]
        public void Right()
        {
            Assert.Equal("ude", "Hey Dude".Right(3));
            Assert.Equal("Hey Dude", "Hey Dude".Right(300));
        }

        [Fact]
        public void TestWhitelisting()
        {
            Assert.Equal("", "".WhitelistFiltered());
            Assert.Equal("   ", "   ".WhitelistFiltered());
            Assert.Equal("áàâéèêíìîóòôúùûäö., -", "áàâéèêíìîóòôúùûäö., -".WhitelistFiltered());
            Assert.Equal("ABCD", "A#$%^B<>&&;C;:'D".WhitelistFiltered());
            Assert.Equal("0123456789", "0123456789".WhitelistFiltered());
        }

        [Fact]
        private void KeepAlphaNumericAndSpaceChars()
        {
            "Word123 - Two!".KeepAlphaNumericAndSpaceChars().Should().Be("Word123  Two");
        }

        [Fact]
        private void KeepAlphaText()
        {
            "Word123 - Two!".KeepAlphaChars().Should().Be("WordTwo");
        }

        [Fact]
        private void KeepNumberChars()
        {
            "Word123 - Two!".KeepNumberChars().Should().Be("123");
        }

        [Fact]
        private void ToTitleCase()
        {
            "This is camel case".ToTitleCase().Should().Be("This Is Camel Case");
        }
    }
}