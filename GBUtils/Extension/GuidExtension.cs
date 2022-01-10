using System;

namespace GBUtils.Extension
{
    public static class GuidExtension
    {
        /// <summary>
        /// Tries to convert the string to a guid, returns null if it failed
        /// </summary>
        /// <param name="pGuidString"></param>
        /// <returns>The guid, or null when it couldn't be parsed</returns>
        /// <example>Convert a string to a guid, using <see cref="Guid.Empty"/> if it failed:</example>
        public static Guid? TryParseGuid(this string pGuidString)
        {
            try
            {
                Guid g = new Guid(pGuidString);
                return g;
            }
            catch { }

            return Guid.Empty;
        }
    }
}