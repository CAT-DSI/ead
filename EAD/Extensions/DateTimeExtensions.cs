using System;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="DateTime" />
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Getting end datetime of <paramref name="dateTime"/>
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> object</param>
        public static DateTime ToEndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }

        /// <summary>
        /// Getting start datetime of <paramref name="dateTime"/>
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> object</param>
        public static DateTime ToStartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }
    }
}
