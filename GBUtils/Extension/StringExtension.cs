﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GBUtils.Extension
{
    public static class StringExtension
    {
        public const string DefaultJoinSeparator = ", ";

        private static readonly DecoderReplacementFallback decoderReplacementFallback =
            new DecoderReplacementFallback("");

        private static readonly EncoderReplacementFallback encoderReplacementFallback =
                    new EncoderReplacementFallback("");

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
        /// Does an index of, with ignoring the casing
        /// </summary>
        /// <param name="value">The p string.</param>
        /// <param name="searchForThisStringWithoutLookingAtCasing">The p search for this string without looking at casing.</param>
        /// <returns></returns>
        public static int IndexOfIc(this string value, string searchForThisStringWithoutLookingAtCasing)
        {
            if (string.IsNullOrEmpty(value))
                return -1;
            return value.IndexOf(searchForThisStringWithoutLookingAtCasing, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Alternative for !string.IsNullOrEmpty("string")
        /// Use: "string".IsOk
        /// </summary>
        /// <param name="value"> The string to check</param>
        /// <returns>
        ///     <c> true</c> if the specified p string is ok; otherwise, <c>false</c> .
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1820:TestForEmptyStringsUsingStringLength")]
        public static bool IsNotNullOrEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return value.Trim() != string.Empty;
        }

        /// <summary>
        /// Inverse version of IsNotNullOrEmpty
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        ///     <c> true</c> if [is not ok] [the specified p string]; otherwise, <c>false</c> .
        /// </returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return !IsNotNullOrEmpty(value);
        }

        /// <summary>
                /// Determines whether if value is one of the allowedValues
                /// </summary>
                /// <param name="value"> The value string.</param>
                /// <param name="allowedValues"> The allowed values.</param>
                /// <returns>
                ///     <c> true</c> if value is one of [the specified allowed values]; otherwise, <c>false</c> .
                /// </returns>
        public static bool IsOneOf(this string value, params string[] allowedValues)
        {
            if (value == null || allowedValues == null || allowedValues.Length == 0)
                return false;

            foreach (string allowValue in allowedValues)
            {
                if (value.Equals(allowValue, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static string KeepAlphaChars(this string input)
        {
            return Regex.Replace(input, "[^a-zA-Z]+", "");
        }

        public static string KeepAlphaNumericAndSpaceChars(this string input)
        {
            return Regex.Replace(input, @"[^a-zA-Z0-9\s]+", "");
        }

        public static string KeepNumberChars(this string input)
        {
            return Regex.Replace(input, "[^0-9]+", "");
        }

        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from left</returns>
        public static string Left(this string value, int length)
        {
            return value.Length > length ? value.Substring(0, length) : value;
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
        /// Match a pattern like:
        ///
        /// *.txt;*.jpg;
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

        /// <summary>
        /// Replace a string without looking at the casing
        /// </summary>
        /// <param name="original">The string to operate on</param>
        /// <param name="replaceThis">String to replace</param>
        /// <param name="withThis">Replacement for the replace</param>
        /// <returns></returns>
        public static string ReplaceIc(this string original,
                    string replaceThis, string withThis)
        {
            int count = 0;
            int position0 = 0;
            int position1;
            string upperString = original.ToUpper();
            string upperPattern = replaceThis.ToUpper();
            int inc = (original.Length / replaceThis.Length) *
                      (withThis.Length - replaceThis.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern,
                                              position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < withThis.Length; ++i)
                    chars[count++] = withThis[i];
                position0 = position1 + replaceThis.Length;
            }
            if (position0 == 0) return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            return new string(chars, 0, count);
        }

        /// <summary>
        /// Returns characters from right of specified length
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from right</returns>
        public static string Right(this string value, int length)
        {
            return value.Length > length ? value.Substring(value.Length - length) : value;
        }

        /// <summary>
        /// Startses the with ic.
        /// </summary>
        /// <param name="input"> The string.</param>
        /// <param name="searchForThisStringWithoutLookingAtCasing"> The search for this string without looking at casing.</param>
        /// <returns></returns>
        public static bool StartsWithIc(this string input, string searchForThisStringWithoutLookingAtCasing)
        {
            if (string.IsNullOrEmpty(input) || searchForThisStringWithoutLookingAtCasing == null)
                return false;
            return input.StartsWith(searchForThisStringWithoutLookingAtCasing, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Starts with one of the values (ignore case).
        /// </summary>
        /// <param name="pString">The p string.</param>
        /// <param name="pValues">The p values.</param>
        /// <returns></returns>
        public static bool StartsWithIcOneOf(this string pString, params string[] pValues)
        {
            return pString.StartsWithIcOneOf(false, pValues);
        }

        /// <summary>
        /// Starts with one of the values (trim first and ignore case)
        /// </summary>
        /// <param name="pString"> The p string.</param>
        /// <param name="pTrimBeforeCompare"> if set to <c>true </c> [p trim before compare].</param>
        /// <param name="pValues"> The p values.</param>
        /// <returns></returns>
        public static bool StartsWithIcOneOf(this string pString, bool pTrimBeforeCompare, params string[] pValues)
        {
            if (pString == null || pValues == null || pValues.Length == 0)
                return false;

            foreach (string value in pValues)
            {
                if (pTrimBeforeCompare)
                {
                    if (pString.Trim().StartsWithIc(value.Trim()))
                        return true;
                }
                else
                {
                    if (pString.StartsWithIc(value))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Same as Substring function with one difference it will not return errors when invalid positions are given.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="position"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringLeft(this string value, int position, int length)
        {
            string val = value;
            if (val == null)
            {
                return string.Empty;
            }
            if (length <= 0)
            {
                return string.Empty;
            }
            if (position > value.Length)
            {
                return string.Empty;
            }
            int len = length;
            if ((position + len) > value.Length)
            {
                len = value.Length - position;
            }
            val = value.Substring(position, len);
            return val;
        }

        /// <summary>
        /// Same as substring only from right to left
        /// </summary>
        /// <returns></returns>
        public static string SubstringRight(this string value, int position, int length)
        {
            string val = value;
            if (val == null)
            {
                return string.Empty;
            }
            if (length <= 0)
            {
                return string.Empty;
            }
            if (position > value.Length)
            {
                return string.Empty;
            }
            int len = length;
            int endPos = value.Length - position;
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
            val = value.Substring(pos, len);
            return val;
        }

        /// <summary>
        /// Converts every word in a sentence to start with a capital letter
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string original)
        {
            if (string.IsNullOrEmpty(original))
                return "";

            // Check if there are words that contain all capitals
            var splitted = original.Split(' ');
            string joined = "";
            foreach (var s in splitted)
            {
                if (s.All(char.IsUpper))
                {
                    joined += s.ToLowerInvariant() + " ";
                }
                else
                {
                    joined += s + " ";
                }
            }

            return Regex.Replace(joined, @"\b\w", m => m.ToString().ToUpper()).Trim();
        }

        /// <summary>
        /// Truncates a string to a desired length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength, string appendWhenTruncated = "")
        {
            if (maxLength <= 0)
            {
                return value;
            }
            string truncated = value.Left(maxLength);
            if (truncated.Length != value.Length)
            {
                truncated += appendWhenTruncated;
            }
            return truncated;
        }

        /// <summary>
        /// Keeps alphanumeric, spaces, dots, commas and dashes.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
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
                if (!string.IsNullOrEmpty(normalized) && CharUtils.IsWhitelisted(normalized[0]))
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
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
    }
}