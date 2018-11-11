using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateModifier
{
    class DateModifier
    {
        public int ClaculateDaysDiffernce(string start, string end)
        {
            int diference = 0;

            DateTime startDate = DateTime.ParseExact(start, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(end, "yyyy MM dd", CultureInfo.InvariantCulture);
            TimeSpan diff = endDate.Subtract(startDate);
            diference = diff.Days;

            return Math.Abs(diference);
        }
    }
}
