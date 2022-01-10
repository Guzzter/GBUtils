using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GBUtils.Test
{
    public class WhenUsingSeparatorStringBuilder
    {
        [Fact]
        public void Given_DuplicateKeys_Expect_UniqueListWhenUsingToString()
        {
            //Arrange.
            SeparatorStringBuilder separatorStringBuilder = new SeparatorStringBuilder(";");
            separatorStringBuilder.AppendUniqueKey("umbrella", "keyOne");
            separatorStringBuilder.AppendUniqueKey("sunshine", "keyTwo");
            separatorStringBuilder.AppendUniqueKey("raindrop", "keyTwo");

            //Act.
            string result = separatorStringBuilder.ToString();

            //Assert.
            result.Should().Be("umbrella;sunshine");
        }

        [Fact]
        public void Given_DuplicateValues_Expect_UniqueListWhenUsingToString()
        {
            //Arrange.
            SeparatorStringBuilder separatorStringBuilder = new SeparatorStringBuilder(";");
            separatorStringBuilder.AppendUnique("umbrella");
            separatorStringBuilder.AppendUnique("umbrella");
            separatorStringBuilder.AppendUnique("sunshine");

            //Act.
            string result = separatorStringBuilder.ToString();

            //Assert.
            result.Should().Be("umbrella;sunshine");
            separatorStringBuilder.Count.Should().Be(2);
        }

        [Fact]
        public void Given_NormalAppends_Expect_StringWithPipeSeparatedValues()
        {
            //Arrange.
            string wrong = null;
            SeparatorStringBuilder separatorStringBuilder = new SeparatorStringBuilder(",");
            separatorStringBuilder.Append("value 1");
            separatorStringBuilder.Append("");
            separatorStringBuilder.Append(wrong);
            separatorStringBuilder.Append("value 2");

            //Act.
            string newSeparator = "|";
            separatorStringBuilder.Separator = newSeparator;
            string result = separatorStringBuilder.ToString();

            //Assert.
            result.Should().Be("value 1|value 2");
        }

        [Fact]
        public void Given_Values_Expect_SortedList()
        {
            //Arrange.
            SeparatorStringBuilder separatorStringBuilder = new SeparatorStringBuilder(";");
            separatorStringBuilder.Append("umbrella");
            separatorStringBuilder.Append("sunshine");
            separatorStringBuilder.Append("raindrop");

            //Act.
            bool sort = true;
            List<string> result = separatorStringBuilder.GetList(sort);

            //Assert.
            result[0].Should().Be("raindrop");
            result[1].Should().Be("sunshine");
            result[2].Should().Be("umbrella");
        }

        [Fact]
        public void Given_Values_Expect_SortedString()
        {
            //Arrange.
            SeparatorStringBuilder separatorStringBuilder = new SeparatorStringBuilder(" => ");
            separatorStringBuilder.Append("umbrella");
            separatorStringBuilder.Append("sunshine");
            separatorStringBuilder.Append("raindrop");

            //Act.
            string result = separatorStringBuilder.ToStringSorted();

            //Assert.
            result.Should().Be("raindrop => sunshine => umbrella");
        }
    }
}