using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GBUtils.Extension
{
    public static class StringHtmlExt
    {
        public static string StripHTML(this string htmlString)
        {
            //This pattern Matches everything found inside html tags;
            //(.|\n) - > Look for any character or a new line
            // *?  -> 0 or more occurences, and make a non-greedy search meaning
            //That the match will stop at the first available '>' it sees, and not at the last one
            //(if it stopped at the last one we could have overlooked
            //nested HTML tags inside a bigger HTML tag..)
            // Thanks to Oisin and Hugh Brown for helping on this one...
            string pattern = @"<(.|\n)*?>";
            return Regex.Replace(htmlString, pattern, string.Empty);
        }

        /// <summary>
        /// Does the same as NormalizeCharacters but then converts like &#129; ('ü') to 'u'
        /// </summary>
        /// <param name="pText"></param>
        /// <returns></returns>
        public static string NormalizeHtmlCharacters(this string pText)
        {
            string t = pText;
            t = t.Replace("&#128;", "C");
            t = t.Replace("&#129;", "u");
            t = t.Replace("&#130;", "e");
            t = t.Replace("&#131;", "a");
            t = t.Replace("&#132;", "a");
            t = t.Replace("&#133;", "a");
            t = t.Replace("&#134;", "a");
            t = t.Replace("&#135;", "c");
            t = t.Replace("&#136;", "e");
            t = t.Replace("&#137;", "e");
            t = t.Replace("&#138;", "e");
            t = t.Replace("&#139;", "i");
            t = t.Replace("&#140;", "i");
            t = t.Replace("&#141;", "i");
            t = t.Replace("&#142;", "A");
            t = t.Replace("&#143;", "A");
            t = t.Replace("&#144;", "E");
            t = t.Replace("&#147;", "o");
            t = t.Replace("&#148;", "o");
            t = t.Replace("&#149;", "o");
            t = t.Replace("&#150;", "u");
            t = t.Replace("&#151;", "u");
            t = t.Replace("&#152;", "y");
            t = t.Replace("&#153;", "O");
            t = t.Replace("&#154;", "U");
            t = t.Replace("&#160;", "a");
            t = t.Replace("&#161;", "i");
            t = t.Replace("&#162;", "o");
            t = t.Replace("&#163;", "u");
            t = t.Replace("&#164;", "n");
            t = t.Replace("&#165;", "N");
            return t;

        }

        /// <summary>
        /// changes characters like 'ë' to their normal equivalent 'e'
        /// this function is usefull for a string search special char insensitive.
        /// </summary>
        /// <param name="pText"></param>
        /// <returns></returns>
        public static string NormalizeCharacters(this string pText)
        {
            string t = pText;
            t = t.Replace("Ç", "C");
            t = t.Replace("ü", "u");
            t = t.Replace("ü", "u");
            t = t.Replace("é", "e");
            t = t.Replace("â", "a");
            t = t.Replace("ä", "a");
            t = t.Replace("à", "a");
            t = t.Replace("å", "a");
            t = t.Replace("ç", "c");
            t = t.Replace("ë", "e");
            t = t.Replace("è", "e");
            t = t.Replace("ï", "i");
            t = t.Replace("î", "i");
            t = t.Replace("ì", "i");
            t = t.Replace("Ä", "A");
            t = t.Replace("Å", "A");
            t = t.Replace("É", "E");
            t = t.Replace("ô", "o");
            t = t.Replace("ò", "o");
            t = t.Replace("û", "u");
            t = t.Replace("ù", "u");
            t = t.Replace("ÿ", "y");
            t = t.Replace("Ö", "O");
            t = t.Replace("Ü", "U");
            t = t.Replace("ƒ", "f");
            t = t.Replace("¡", "i");
            return t;
        }
    }
}
