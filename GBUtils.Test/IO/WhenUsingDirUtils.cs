using FluentAssertions;
using GBUtils.IO;
using Xunit;

namespace GBUtils.Test.IO
{
    public class WhenUsingDirUtils
    {
        [Fact]
        public void Given_NonExistingDrive_Expect_C_Drive()
        {
            //Arrange.
            string nonExistingPath = "r:\\drive\\not\\here";

            //Act.
            string resolveddir = DirUtils.GetNearestPossibleDir(nonExistingPath);

            //Assert.
            resolveddir.Should().Be("c:\\");
        }

        [Fact]
        public void Given_PathWithDirNonExisting_Expect_NearestExistingDirToBeReturned()
        {
            //Arrange.
            string nonExistingPath = "c:\\windows\\blah\\blah\\etc";

            //Act.
            string resolveddir = DirUtils.GetNearestPossibleDir(nonExistingPath);

            //Assert.
            resolveddir.Should().Be("c:\\windows");
        }

        [Fact]
        public void Given_PathWithDirNonExisting_Expect_Root()
        {
            //Arrange.
            string nonExistingPath = "c:\\does\\dot\\work";

            //Act.
            string resolveddir = DirUtils.GetNearestPossibleDir(nonExistingPath);

            //Assert.
            resolveddir.Should().Be("c:\\");
        }
    }
}