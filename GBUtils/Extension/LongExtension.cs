using System;
using System.Globalization;

namespace GBUtils.Extension
{
    public static class LongExtension
    {
        /// <summary>
        /// Creates a human readable string displaying the size.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>2.3 MG</returns>
        public static string FormatBytes(this long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return string.Format(new CultureInfo("en-US"), "{0:0.##} {1}", dblSByte, Suffix[i]);
        }
    }
}