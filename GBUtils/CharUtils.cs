namespace GBUtils.Extension
{
    public static class CharUtils
    {
        private const char Max9 = '9';
        private const char MaxCapZ = 'Z';
        private const char MaxZ = 'z';
        private const char Min0 = '0';
        private const char MinA = 'a';
        private const char MinCapA = 'A';

        /// <summary>
        /// Is it a-z or A-Z?
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsBasicLetter(char c)
        {
            return (MinCapA <= c && c <= MaxCapZ) || (MinA <= c && c <= MaxZ);
        }

        /// <summary>
        /// Is it 0-9?
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsDigit(char c)
        {
            return (Min0 <= c && c <= Max9);
        }

        /// <summary>
        /// Is it a space, dot, comma or dash?
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSpecialChar(char c)
        {
            return c == ' ' || c == ',' || c == '.' || c == '-';
        }

        /// <summary>
        /// Keeps alphanumeric, spaces, dots, commas and dashes.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsWhitelisted(char c)
        {
            return IsBasicLetter(c) || IsDigit(c) || IsSpecialChar(c);
        }
    }
}