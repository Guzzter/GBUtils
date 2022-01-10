using System;
using System.IO;

namespace GBUtils.IO
{
    public static class FileUtils
    {
        /// <summary>
        /// Creates the temporary file with the given extension and returns its full path.
        /// </summary>
        /// <param name="contentBytes"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string CreateTempFile(byte[] contentBytes, string extension)
        {
            var fullFileName = CreateTempFilePath(extension);
            File.WriteAllBytes(fullFileName, contentBytes);
            return fullFileName;
        }

        /// <summary>
        /// The create temp file path.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateTempFilePath(string extension)
        {
            var path = Path.GetTempPath();
            var fileName = Guid.NewGuid() + (extension.IsBlank() ? string.Empty : "." + extension);
            var fullFileName = Path.Combine(path, fileName);
            return fullFileName;
        }

        public static string StripExtension(this string path)
        {
            if (string.IsNullOrEmpty(path)) return path;

            return Path.GetFileNameWithoutExtension(path);
        }
    }
}