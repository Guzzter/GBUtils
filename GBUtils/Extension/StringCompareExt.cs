using System;

namespace GBUtils.Extension
{
    /// <summary>
    /// Contains extensions for comparing strings
    /// </summary>
    public static class StringCompareExt
    {
        /// <summary>
        /// Searches for occurences in a string with case-sensitivity
        /// </summary>
        /// <param name="haystack">String to be searched</param>
        /// <param name="allNeedles">Strings to search for</param>
        /// <returns>true if one the needles is found in haystack</returns>
        public static bool ContainsOneOf(this string haystack, params string[] allNeedles)
        {
            if (allNeedles == null)
                return false;

            bool found = false;

            //if (others == null)
            //  return found;

            foreach (var needle in allNeedles)
            {
                if (haystack.Contains(needle))
                    found = true;
            }

            return found;
        }

        /// <summary>
        /// Searches for occurences in a string with case-insensitivity
        /// </summary>
        /// <param name="haystack">String to be searched</param>
        /// <param name="allNeedles">Strings to search for</param>
        /// <returns>true if one the needles is found in haystack</returns>
        public static bool ContainsOneOfIc(this string haystack, params string[] allNeedles)
        {
            bool found = false;
            if (allNeedles == null)
                return false;

            foreach (var needle in allNeedles)
            {
                if (haystack.ToLowerInvariant().Contains(needle.ToLowerInvariant()))
                    found = true;
            }

            return found;
        }

        /// <summary>
        /// Alternative for Equals - directly with case-insensitivity
        /// </summary>
        /// <param name="source">string to start compare</param>
        /// <param name="match">with other string</param>
        /// <returns></returns>
        public static bool EqualsIc(this string source, string match)
        {
            return source.Equals(match, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks string object's value to array of string values
        /// </summary>
        /// <param name="source">String to evaluate</param>
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool In(this string source, params string[] stringValues)
        {
            if (stringValues == null)
                return false;

            foreach (string otherValue in stringValues)
                if (string.Compare(source, otherValue) == 0)
                    return true;

            return false;
        }

        /// <summary>
        /// Checks if string starts with something with case insensitivity
        /// </summary>
        /// <param name="source">String to evaluate</param>
        /// <param name="startString">Value to check</param>
        /// <param name="trimFirst">Optionally you can turn trim on white spaces off (default is true)</param>
        /// <returns>True when source string starts with startString</returns>
        public static bool StartsWithIc(this string source, string startString, bool trimFirst = true)
        {
            if (string.IsNullOrWhiteSpace(startString))
                return false;

            if (trimFirst)
            {
                source = source.Trim();
                startString = startString.Trim();
            }
            return (source.ToLowerInvariant().StartsWith(startString.ToLowerInvariant()));
        }
    }
}