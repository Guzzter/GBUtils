using GBUtils.Extension;
using Xunit;

namespace GBUtils.Test.Extension
{
    public class WhenUsingLongExtension
    {
        [Fact]
        public void FormatBytes_Should_Return_HumanReadableString()
        {
            long size = (1024 * 1024);
            Assert.Equal("1 MB", size.FormatBytes());
            size = (1024 * 1024 * 1024 - 1);
            Assert.Equal("1024 MB", size.FormatBytes());
            size = (1024 * 1024 + 600000);
            Assert.Equal("1.57 MB", size.FormatBytes());
        }
    }
}