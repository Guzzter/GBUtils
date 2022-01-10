namespace GBUtils.Extension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class EnumerableExtension
    {
        private static readonly UTF8Encoding encoding = new UTF8Encoding();

        public static string Join<T>(this IEnumerable<T> elements, Func<T, string> selector, string separator)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            return Join(elements.Select(selector), separator);
        }

        public static string Join<T>(this IEnumerable<T> elements, Func<T, string> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            return Join(elements.Select(selector), StringExtension.DefaultJoinSeparator);
        }

        public static string Join<T>(this IEnumerable<T> elements, Func<T, string> selector, char separator)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            return Join(elements.Select(selector), separator);
        }

        public static string Join(this IEnumerable<string> strings, char separator)
        {
            return Join(strings, Convert.ToString(separator));
        }

        public static string Join(this IEnumerable<string> strings, string separator)
        {
            if (strings == null) return String.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (string value in strings)
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (sb.Length > 0) sb.Append(separator);
                    sb.Append(value);
                }
            }
            return sb.ToString();
        }

        public static string Join(this IEnumerable<string> strings)
        {
            return Join(strings, StringExtension.DefaultJoinSeparator);
        }

        public static byte[] ToByteArray(this string source)
        {
            if (source == null)
            {
                source = String.Empty;
            }
            return encoding.GetBytes(source);
        }
    }
}