using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public static int DateDifferance(string startDate, string endDate)
        {
            DateTime startTime = DateTime.Parse(startDate);
            DateTime endTime = DateTime.Parse(endDate);

            TimeSpan differance = endTime - startTime;

            return Math.Abs(differance.Days);
        }
    }
}
