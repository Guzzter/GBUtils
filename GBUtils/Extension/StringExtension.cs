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

    }
}