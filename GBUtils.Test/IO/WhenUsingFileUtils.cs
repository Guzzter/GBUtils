using GBUtils.IO;
using Xunit;

namespace GBUtils.Test.IO
{
    public class WhenUsingFileUtils
    {
        [Fact]
        public void StripExtension()
        {
            Assert.Equal("readme", "readme.txt".StripExtension());
            Assert.Equal("readme.config", "readme.config.txt".StripExtension());
        }
    }
}