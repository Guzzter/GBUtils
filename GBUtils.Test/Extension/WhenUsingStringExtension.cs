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
        public void Given_A_String_Expect_ToBeOneOf()
        {
            "ocean".IsOneOf("sea", "lake", "river").Should().BeFalse();
            "ocean".IsOneOf("sea", "ocean", "river").Should().BeTrue();
        }

        [Fact]
        public void Given_NormalSentence_Expect_EveryWordStartingWithUppercase()
        {
            //Assert.
            "This is a sentence".ToTitleCase().Should().Be("This Is A Sentence");
        }

        [Fact]
        public void Given_StartsWithIcOneOf_Expect_MatchingStartIgnoringTheCasing()
        {
            //Assert.
            "This is".StartsWithIcOneOf("this", "that").Should().BeTrue();
            "this is".StartsWithIcOneOf("this", "that").Should().BeTrue();
            "what is".StartsWithIcOneOf("this", "that").Should().BeFalse();
            " This is".StartsWithIcOneOf("this", "that").Should().BeFalse();
            "".StartsWithIcOneOf("this", "that").Should().BeFalse();
        }

        [Fact]
        public void Given_StartsWithIcOneOf_Expect_MatchingStartIgnoringTheCasingWithTrim()
        {
            //Assert.
            " This is".StartsWithIcOneOf(true, "this", "that").Should().BeTrue();
            "This is".StartsWithIcOneOf(true, " this", "that").Should().BeTrue();
        }

        [Fact]
        public void Given_StringWithDifferentCasing_Expect_ToReplaceIgnoringTheCasing()
        {
            //Arrange.
            string value = "This is AMAZING";
            string replace = "amazing";
            string replacement = "cool";

            //Act.
            string result = value.ReplaceIc(replace, replacement);

            //Assert.
            result.Should().Be("This is cool");
        }

        [Fact]
        public void Given_SubstringLeft_Expect_FullStringWhenSubstringIsOutOfBounds()
        {
            //Assert.
            "This is not so long".SubstringLeft(5, 9).Should().Be("is not so");
            "This is not so long".SubstringLeft(20, 9).Should().Be("");
            "This is not so long".SubstringLeft(5, 6).Should().Be("is not");
            "This is not so long".SubstringLeft(5, 200).Should().Be("is not so long");
            "This is not so long".SubstringLeft(5, 0).Should().Be("");
        }

        [Fact]
        public void Given_SubstringRight_Expect_FullStringWhenSubstringIfOutOfBounds()
        {
            //Assert.
            "Lorem Ipsum Dolor Sit Amet".SubstringRight(0, 8).Should().Be("Sit Amet");
            "Lorem Ipsum Dolor Sit Amet".SubstringRight(6, 8).Should().Be("Dolor Si");
            "Lorem Ipsum Dolor Sit Amet".SubstringRight(21, 5).Should().Be("Lorem");
            "Lorem Ipsum Dolor Sit Amet".SubstringRight(200, 5).Should().Be("");
            "Lorem Ipsum Dolor Sit Amet".SubstringRight(8, 0).Should().Be("");
        }

        [Fact]
        public void Given_TrunctionExtension_Expect_TextToBeTruncated()
        {
            //Assert.
            "".Truncate(5).Should().Be("");
            "Where ever you go".Truncate(0).Should().Be("Where ever you go");
            "Where ever you go".Truncate(-1).Should().Be("Where ever you go");
            "Where ever you go".Truncate(5).Should().Be("Where");
            "Where ever you go".Truncate(5, "...").Should().Be("Where...");
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