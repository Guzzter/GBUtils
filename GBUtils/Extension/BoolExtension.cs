using System;
using System.Collections.Generic;
using System.Text;

namespace GBUtils.Extension
{
    public static class BoolExtension
    {
        /// <summary>
        /// Converts the boolean to an int. 1 for true, 0 for false.
        /// </summary>
        /// <param name="pBoolean">if set to <c>true</c> [p boolean].</param>
        /// <returns></returns>
        public static int ToInt(this bool pBoolean)
        {
            return pBoolean ? 1 : 0;
        }
    }
}