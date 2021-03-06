﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBUtils.Extension
{
    public static class EnumExtension
    {

        /// <summary>
        /// Converts string to enum object
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this string value, T defaultValue)
            where T : struct
        {
            T parsedEnum = defaultValue;
            Enum.TryParse(value, true, out parsedEnum);
            return parsedEnum;
        }

    }
}
