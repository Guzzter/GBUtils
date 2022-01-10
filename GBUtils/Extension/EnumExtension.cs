using System;

namespace GBUtils.Extension
{
    public static class EnumExtension
    {
        /// <summary> Converts string to enum object, throws e </summary> <typeparam name="T">Type of enum</typeparam> <param name="value">String
        /// value to convert</param> <returns>Returns enum object</returns> <exception cref=""
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static T ToEnum<T>(this string value, T defaultValue)
            where T : struct
        {
            T parsedEnum;
            if (Enum.TryParse(value, true, out parsedEnum))
            {
                return parsedEnum;
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets the name of the enum value.
        /// </summary>
        /// <param name="pEnum">The enum.</param>
        /// <returns></returns>
        public static string ToStringName(this Enum pEnum)
        {
            return Enum.GetName(pEnum.GetType(), pEnum);
        }
    }
}