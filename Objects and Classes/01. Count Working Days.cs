using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            var Holidays = new List<string>
            {
                "01 01",
                "03 03",
                "01 05",
                "06 05",
                "24 05",
                "06 09",
                "22 09",
                "01 11",
                "24 12",
                "25 12",
                "26 12"

            }.Select(a => DateTime.ParseExact(a, "dd MM", CultureInfo.InvariantCulture));

            var startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var countWorkingDays = 0;

            for (DateTime currentDay = startDate; currentDay <= endDate; currentDay = currentDay.AddDays(1))
            {
                if (currentDay.DayOfWeek != DayOfWeek.Saturday
                    && currentDay.DayOfWeek != DayOfWeek.Sunday
                    && !Holidays.Any(d => d.Day == currentDay.Day && d.Month == currentDay.Month))
                {
                    countWorkingDays++;
                }
            }
            Console.WriteLine(countWorkingDays);
        }
    }
}