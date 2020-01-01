using System;
using System.Collections.Generic;

namespace EHRS.Shared
{
    /// <summary>
    /// Provides extension utility methods for Date and Time processing,
    /// Author : TMC 
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the last day of month.
        /// </summary>
        /// <param name="dtDate">The dt date.</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime dtDate)
        {
            // set return value to the last day of the month 
            // for any date passed in to the method 
            // create a datetime variable set to the passed in date 
            DateTime dtTo = dtDate;
            // overshoot the date by a month 
            dtTo = dtTo.AddMonths(1);
            // remove all of the days in the next month 
            // to get bumped down to the last day of the 
            // previous month 
            dtTo = dtTo.AddDays(-(dtTo.Day));
            // return the last day of the month 
            return dtTo.Date;
        }

        /// <summary>
        /// Gets the number of days between two dates.
        /// </summary>
        public static int GetNumberOfDaysBetweenDates(this DateTime startDate, DateTime endDate)
        {
            return endDate.Subtract(startDate).Days + 1;
        }

        /// <summary>
        /// Gets the first day of the month.
        /// </summary>
        public static DateTime GetFirstDayOfMonth(this DateTime dtDate)
        {
            // remove all of the days -1 in the next month 
            // to get bumped down to the first day of
            // next month 
            DateTime dtTo = dtDate.AddDays(-(dtDate.Day - 1));
            // return the last day of the month 
            return dtTo.Date;
        }

        /// <summary>
        /// Gets the first day of the next month.
        /// </summary>
        public static DateTime GetFirstDayOfNextMonth(this DateTime dtDate)
        {
            // set return value to the last day of the month 
            // for any date passed in to the method 
            // create a datetime variable set to the passed in date 
            DateTime dtTo = dtDate;
            // overshoot the date by a month 
            dtTo = dtTo.AddMonths(1);
            return GetFirstDayOfMonth(dtTo);
        }

        /// <summary>
        /// Gets the month between two dates.
        /// </summary>
        public static IList<DateTime> GetMonthsBetweenDates(this DateTime startDate, DateTime endDate)
        {
            IList<DateTime> monthList = new List<DateTime>();
            DateTime currentDate = startDate;
            while (currentDate >= startDate && currentDate <= endDate)
            {
                monthList.Add(currentDate.GetFirstDayOfMonth());
                currentDate = currentDate.GetFirstDayOfNextMonth();
            }
            return monthList;
        }

        /// <summary>
        /// Gets the number of hours in the month.
        /// </summary>
        public static int HoursInMonth(DateTime dateTime)
        {
            var firstDate = dateTime.GetFirstDayOfMonth();
            var lastDate = dateTime.GetFirstDayOfMonth();
            return firstDate.GetNumberOfDaysBetweenDates(lastDate)*24;
        }
    }
}