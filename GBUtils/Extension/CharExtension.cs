using System;
using System.Collections.Generic;
using System.Text;

namespace GBUtils.Extension
{
    public static class CharExtension
    {
        /// <summary>
        /// Tries to figure out what kind of bool it contains (When nothing found, the method returns false)
        /// </summary>
        /// <param name="pChar">The p char.</param>
        /// <returns></returns>
        public static bool ToBool(this char pChar)
        {
            if (pChar == '1' || pChar == 'J' || pChar == 'j' || pChar == 'Y' || pChar == 'y' || pChar == '+')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}