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
            Assert.False("DUMMY".ContainsOneOf(null));
        }

        [Fact]
        public void TestContainsOneOfIc()
        {
            Assert.True("DUMMY".ContainsOneOfIc("Bla", "DuMMy"));
            Assert.False("DUMMY".ContainsOneOfIc("Foo", "Bar"));
            Assert.False("DUMMY".ContainsOneOfIc(null));
        }

        [Fact]
        public void TestEqualsIc()
        {
            Assert.True("DUMMY".EqualsIc("DuMMy"));
            Assert.False("DUMMY".EqualsIc(""));
            Assert.False("DUMMY".EqualsIc(null));
        }

        [Fact]
        public void TestIn()
        {
            Assert.False("DUMMY".In("DuMMy", "bla"));
            Assert.True("DUMMY".In("bla", "DUMMY"));
            Assert.False("DUMMY".In(""));
            Assert.False("DUMMY".In(null));
        }

        [Fact]
        public void TestStartsWithIc()
        {
            Assert.True("DUMMY".StartsWithIc("DuM"));
            Assert.True("DUMMY".StartsWithIc(""));
            Assert.False("DUMMY".StartsWithIc(null));
        }
    }
}