using GBUtils.IO;
using Xunit;

namespace GBUtils.Test.IO
{
    public class WhenUsingFilePathFormatter
    {
        [Fact]
        public void FilePathFormatter_Should_FormatFilePathForDisplaying()
        {
            string path = @"c:\temp\readme.txt";
            Assert.Equal(@"", FilePathFormatter.Format("", FilePathFormat.Ellipsis));
            Assert.Equal(path, FilePathFormatter.Format(path, FilePathFormat.Full));
            Assert.Equal(@"c:\...\temp\readme.txt", FilePathFormatter.Format(path, FilePathFormat.Ellipsis));
            Assert.Equal(@"c:\temp", FilePathFormatter.Format(path, FilePathFormat.FullDir));
            Assert.Equal(@"readme.txt", FilePathFormatter.Format(path, FilePathFormat.Short));
            Assert.Equal(@"readme.txt (c:\temp)", FilePathFormatter.Format(path, FilePathFormat.ShortFileFullDir));
        }
    }
}