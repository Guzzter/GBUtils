namespace GBUtils.Extension
{
    using System;

    public static class DateTimeExtension
    {
        /// <summary>
        /// SQL Server mindate (for datetime fields)
        /// </summary>
        public static readonly DateTime SqlServerDate = new DateTime(1753, 1, 1);

        /// <summary>
        /// Converts from SqlServer min date to <c>DateTime.MinValue</c> if required.
        /// </summary>
        /// <param name="dateTime">Date/Time in sqlServer</param>
        /// <returns>Proper .NET date</returns>
        public static DateTime FromSqlServer(this DateTime dateTime)
        {
            if (dateTime.Year == 1753 && dateTime.Month == 1 && dateTime.Day == 1)
                return DateTime.MinValue;

            return dateTime;
        }

        public static DateTime LookupDateOfWeek(this DateTime dt, DayOfWeek seekDayOfWeek)
        {
            if (seekDayOfWeek == DayOfWeek.Sunday || seekDayOfWeek > dt.DayOfWeek)
            {
                int diff = seekDayOfWeek - dt.DayOfWeek;

                // Fix for sunday == end of the week
                if (diff < 0)
                {
                    diff = 7 + diff;
                }
                var date = dt.AddDays(diff).Date;
                return date;
            }
            else
            {
                int diff = dt.DayOfWeek - seekDayOfWeek;
                return dt.AddDays(-1 * diff).Date;
            }
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Converts from SqlServer min date to <c>DateTime.MinValue</c> if required.
        /// </summary>
        /// <param name="dateTime">Date/Time in sqlServer</param>
        /// <returns>Proper .NET date</returns>
        public static DateTime ToSqlServer(this DateTime dateTime)
        {
            return dateTime == DateTime.MinValue ? new DateTime(1753, 1, 1) : dateTime;
        }
    }
}