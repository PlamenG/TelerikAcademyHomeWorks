// Write a method that calculates the number of workdays between today and given date, 
// passed as parameter. Consider that workdays are all days from Monday to Friday except 
// a fixed list of public holidays specified preliminary as array.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.WorkdaysCalculator
{
    static class WorkdaysCalculator
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            DateTime[] bankHolidays =
            {
                new DateTime (2013, 1, 1),
                new DateTime (2013, 3, 3),
                new DateTime (2013, 5, 1),
                new DateTime (2013, 5, 2),
                new DateTime (2013, 5, 3),
                new DateTime (2013, 5, 5),
                new DateTime (2013, 5, 6),
                new DateTime (2013, 5, 24),
                new DateTime (2013, 9, 6),
                new DateTime (2013, 9, 22),
                new DateTime (2013, 11, 1),
                new DateTime (2013, 12, 24),
                new DateTime (2013, 12, 25),
                new DateTime (2013, 12, 26),
                new DateTime (2013, 12, 31),
            };

            
            DateTime firstDay = DateTime.Today;
            DateTime lastDay = InputTargetDate();
            int Result = BusinessDaysUntil(firstDay, lastDay, bankHolidays);
            PrintResult(Result, lastDay);
        }

        private static void PrintResult(int Result, DateTime lastDay)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string Format = "dd/MM/yy"; // it is specified what needs to be displayed
            Console.WriteLine("\nThe working days between {0} and {1} are {2}.\n", DateTime.Today.ToString(Format), lastDay.ToString(Format), Result);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static DateTime InputTargetDate()
        {
            Console.Write("Please, enter a date in the future: ");
            DateTime lastDay = DateTime.Parse(Console.ReadLine());
            
            return lastDay;
        }


        // source - http://stackoverflow.com/questions/1617049/calculate-the-number-of-business-days-between-two-dates

        /// <summary>
        /// Calculates number of business days, taking into account:
        ///  - weekends (Saturdays and Sundays)
        ///  - bank holidays in the middle of the week
        /// </summary>
        /// <param name="firstDay">First day in the time interval</param>
        /// <param name="lastDay">Last day in the time interval</param>
        /// <param name="bankHolidays">List of bank holidays excluding weekends</param>
        /// <returns>Number of business days during the 'span'</returns>
        public static int BusinessDaysUntil(this DateTime firstDay, DateTime lastDay, params DateTime[] bankHolidays)
        {
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            if (firstDay > lastDay) // Check if the input is valid
                throw new ArgumentException("Incorrect last day " + lastDay);

            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = firstDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)firstDay.DayOfWeek;
                int lastDayOfWeek = lastDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7; // in order to make the calculation work - example: first day is Friday and last day is Monday if there is no +=7 Monday will have lower value.
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                    businessDays -= 1;
            }

            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;

            // subtract the number of bank holidays during the time interval
            foreach (DateTime bankHoliday in bankHolidays)
            {
                DateTime bh = bankHoliday.Date;
                if (firstDay <= bh && bh <= lastDay)
                    --businessDays;
            }

            return businessDays;
        }
    }
}
