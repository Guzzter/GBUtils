namespace GBUtils.Extension
{
    using System;

    public static class DateTimeExtension
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
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
    }
}
