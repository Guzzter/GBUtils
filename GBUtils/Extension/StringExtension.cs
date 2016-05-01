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

        /// <summary>
        /// Converts a string from MAINLINE to Mainline
        /// </summary>
        /// <param name="source">String to convert</param>
        /// <returns>Correct cased string</returns>
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

        /// <summary>
        /// Converts a string from mainline to Mainline
        /// </summary>
        /// <param name="source">String to convert</param>
        /// <returns>Correct cased string</returns>
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
            string normalized = source.Normalize(NormalizationForm.FormKD);
            Encoding removal = Encoding.GetEncoding(Encoding.ASCII.CodePage, encoderReplacementFallback,
                                                    decoderReplacementFallback);
            byte[] bytes = removal.GetBytes(normalized);
            return Encoding.ASCII.GetString(bytes);
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
        /// Same as Substring function with one difference it will not return errors when invalid positions are given.
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pPosition"></param>
        /// <param name="pLength"></param>
        /// <returns></returns>
        public static string SubStringLeft(string pValue, int pPosition, int pLength)
        {
            string val = pValue;
            if (val == null)
            {
                return string.Empty;
            }
            if (pLength == 0)
            {
                return string.Empty;
            }
            if (pPosition > pValue.Length)
            {
                return string.Empty;
            }
            int len = pLength;
            if ((pPosition + len) > pValue.Length)
            {
                len = pValue.Length - pPosition;
            }
            val = pValue.Substring(pPosition, len);
            return val;
        }


        /// <summary>
        /// Same as substring only in Mirror from the right
        /// </summary>
        /// <returns></returns>
        public static string SubStringRight(string pValue, int pPosition, int pLength)
        {
            string val = pValue;
            if (val == null)
            {
                return string.Empty;
            }
            if (pLength == 0)
            {
                return string.Empty;
            }
            if (pPosition > pValue.Length)
            {
                return string.Empty;
            }
            int len = pLength;
            string value = pValue;
            int endPos = pValue.Length - pPosition;
            int pos = endPos - len;
            if (pos < 0)
            {
                len = len + pos;
                pos = 0;
            }
            if (len < 0)
            {
                len = 0;
            }
            val = value;
            val = pValue.Substring(pos, len);
            return val;
        }

        /// <summary>
        /// Truncates a string to a desired length
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pMaxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string pValue, int pMaxLength)
        {
            return pValue.Left(pMaxLength);
        }

        /// <summary>
        /// Match a pattern like:
        /// 
        /// *.txt;*.jpg;
        /// 
        /// </summary>
        /// <param name="pText"></param>
        /// <param name="pPattern">Separated pattern</param>
        /// <returns></returns>
        public static bool PatternMatch(this string pText, string pPattern)
        {
            if (pPattern == null)
            {
                return false;
            }
            string[] patterns = pPattern.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            return pText.ContainsOneOfIc(patterns);
        }

        public static string ReplaceIc(this string original,
                    string pattern, string replacement)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) *
                      (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern,
                                              position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0) return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            return new string(chars, 0, count);
        }
    }
}