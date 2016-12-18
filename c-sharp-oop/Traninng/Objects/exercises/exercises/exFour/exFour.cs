using System;

namespace exFour
{
    class exFour
    {
        private static int miliseconds = Environment.TickCount;

        static void Main()
        {
            decimal minutes = GetMinutes(miliseconds);
            decimal hours = GetHours(minutes);
            decimal days = GetDays(hours);
            Console.WriteLine($"Days: {days}");
            Console.WriteLine($"Hours: {hours}");
            Console.WriteLine($"Minutes: {minutes}");
        }

        private static decimal GetDays(decimal hours)
        {
            decimal result = hours / 24M;
            return result;
        }

        private static decimal GetHours(decimal minutes)
        {
            decimal result = minutes / 60M;
            return result;
        }

        private static decimal GetMinutes(int miliseconds)
        {
            decimal result = miliseconds / 60000M;
            return result;
        }
    }
}
