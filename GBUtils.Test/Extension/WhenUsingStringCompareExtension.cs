using GBUtils.Extension;
using Xunit;

namespace GBUtils.Test.Extension
{
    public class WhenUsingStringCompareExtension
    {
        [Fact]
        public void TestContainsOneOf()
        {
            Assert.False("DUMMY".ContainsOneOf("Bla", "DuMMy"));
            Assert.True("DUMMY".ContainsOneOf("Foo", "Bar", "DUMMY"));
        }

        [Fact]
        public void TestContainsOneOfIc()
        {
            Assert.True("DUMMY".ContainsOneOfIc("Bla", "DuMMy"));
            Assert.False("DUMMY".ContainsOneOfIc("Foo", "Bar"));
        }

        [Fact]
        public void TestEqualsIc()
        {
            Assert.True("DUMMY".EqualsIc("DuMMy"));
            Assert.False("DUMMY".EqualsIc(""));
        }

        [Fact]
        public void TestIn()
        {
            Assert.False("DUMMY".In("DuMMy", "bla"));
            Assert.True("DUMMY".In("bla", "DUMMY"));
            Assert.False("DUMMY".In(""));
        }

        [Fact]
        public void TestStartsWithIc()
        {
            Assert.True("DUMMY".StartsWithIc("DuM"));
            Assert.True("DUMMY".StartsWithIc(""));
        }
    }
}