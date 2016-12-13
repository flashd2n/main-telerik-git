using System;

namespace leapYear
{
    class leapYear
    {
        static void Main()
        {
            int year = int.Parse(Console.ReadLine());

            bool isLeap = DateTime.IsLeapYear(year);

            string result = null;

            if (isLeap)
            {
                result = "Leap";
            }
            else
            {
                result = "Common";
            }

            Console.WriteLine(result);
        }
    }
}
