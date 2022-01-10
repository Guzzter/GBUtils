using System;
using Xunit;
using GBUtils.Extension;

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
    }
}