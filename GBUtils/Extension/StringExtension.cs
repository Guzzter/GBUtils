namespace GBUtils.Extension
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtension
    {
        public const string DefaultJoinSeparator = ", ";

        private static readonly EncoderReplacementFallback encoderReplacementFallback =
            new EncoderReplacementFallback("");

        private static readonly DecoderReplacementFallback decoderReplacementFallback =
            new DecoderReplacementFallback("");

        private const char MinCapA = 'A';
        private const char MaxCapZ = 'Z';
        private const char MinA = 'a';
        private const char MaxZ = 'z';
        private const char Min0 = '0';
        private const char Max9 = '9';

        public static string WhitelistFiltered(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (char ch in source)
            {
                string normalized = (ch.ToString(CultureInfo.InvariantCulture)).Normalized();
                if (!string.IsNullOrEmpty(normalized) && IsWhitelisted(normalized[0]))
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        public static string FirstCharacterUppercaseRestLowercase(this string source)
        {
            string result = source;
            if (!string.IsNullOrWhiteSpace(source))
            {
                int length = FirstCharacterLength(source);
                result = source.Substring(0, length).ToUpper();

                if (source.Length > length)
                {
                    result += source.Substring(length).ToLower();
                }
            }

            return result;
        }

        public static string FirstCharacterUppercase(this string source)
        {
            string result = source;
            if (!string.IsNullOrWhiteSpace(source))
            {
                int length = FirstCharacterLength(source);
                result = source.Substring(0, length).ToUpper();

                if (source.Length > length)
                {
                    result += source.Substring(length);
                }
            }

            return result;
        }

        private static int FirstCharacterLength(string source)
        {
            int result = 0;

            if (!string.IsNullOrWhiteSpace(source))
            {
                result = (source.StartsWith("ij", StringComparison.OrdinalIgnoreCase) ? 2 : 1);
            }

            return result;
        }

        private static bool IsWhitelisted(char c)
        {
            return IsBasicLetter(c) || IsDigit(c) || IsSpecialChar(c);
        }

        private static bool IsSpecialChar(char c)
        {
            return c == ' ' || c == ',' || c == '.' || c == '-';
        }

        private static bool IsBasicLetter(char c)
        {
            return (MinCapA <= c && c <= MaxCapZ) || (MinA <= c && c <= MaxZ);
        }

        private static bool IsDigit(char c)
        {
            return (Min0 <= c && c <= Max9);
        }

        public static string Normalized(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            string normalized = source.Normalize(NormalizationForm.FormKD);
            Encoding removal = Encoding.GetEncoding(Encoding.ASCII.CodePage, encoderReplacementFallback,
                                                    decoderReplacementFallback);
            byte[] bytes = removal.GetBytes(normalized);
            return Encoding.ASCII.GetString(bytes);
        }


        public static string With(this string format, params object[] arg0)
        {
            if (format == null) throw new ArgumentNullException("format");
            return string.Format(format, arg0);
        }

        /// <summary>
        /// Returns characters from right of specified length
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from right</returns>
        public static string Right(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(value.Length - length) : value;
        }

        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from left</returns>
        public static string Left(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(0, length) : value;
        }

        /// <summary>
        ///  Replaces the format item in a specified System.String with the text equivalent
        ///  of the value of a specified System.Object instance.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="arg0">An System.Object to format</param>
        /// <returns>A copy of format in which the first format item has been replaced by the
        /// System.String equivalent of arg0</returns>
        public static string Format(this string value, object arg0)
        {
            return string.Format(value, arg0);
        }

        /// <summary>
        ///  Replaces the format item in a specified System.String with the text equivalent
        ///  of the value of a specified System.Object instance.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="args">An System.Object array containing zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the System.String
        /// equivalent of the corresponding instances of System.Object in args.</returns>
        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        /// <summary>
        /// Checks string object's value to array of string values
        /// </summary>        
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool In(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
                if (string.Compare(value, otherValue) == 0)
                    return true;

            return false;
        }

    }
}