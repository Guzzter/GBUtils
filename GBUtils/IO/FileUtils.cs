using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GBUtils.IO
{
    public static class FileUtils
    {
        /// <summary>
        /// Make sure file path is not longer than 260 (Windows limitation) When longer, shorten it.
        /// </summary>
        /// <param name="proposal"></param>
        /// <returns></returns>
        public static string CreateSafeFilePath(string proposal)
        {
            if (proposal.Length >= 260 && proposal.Contains("."))
            {
                int firstDot = proposal.IndexOf('.');
                int tooLong = proposal.Length - 259;
                var firstPart = proposal.Substring(0, firstDot);
                var secondPart = proposal.Substring(firstDot);
                proposal = firstPart.Substring(0, firstPart.Length - tooLong) + secondPart;
            }
            else if (proposal.Length >= 260)
            {
                proposal.Substring(0, 259);
            }
            return proposal;
        }

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

        public static string GetRandomFileName(string extension)
        {
            return Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extension;
        }

        public static bool IsValidFilename(string fileName)
        {
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(Path.GetInvalidPathChars())) + "/]");
            if (containsABadCharacter.IsMatch(fileName)) { return false; };
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(fileName);
            }
            catch (ArgumentException) { }
            catch (PathTooLongException) { }
            catch (NotSupportedException) { }
            if (ReferenceEquals(fi, null))
            {
                return false;
            }
            return true;
        }

        public static string StripExtension(this string path)
        {
            if (string.IsNullOrEmpty(path)) return path;

            return Path.GetFileNameWithoutExtension(path);
        }
    }
}