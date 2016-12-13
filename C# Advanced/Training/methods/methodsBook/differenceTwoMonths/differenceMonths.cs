using System;
using System.Collections.Generic;

namespace differenceTwoMonths
{
    class differenceMonths
    {
        static List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        static void Main()
        {
            string firstMonth = Console.ReadLine();
            string secondMonth = Console.ReadLine();

            Console.WriteLine("There is {0} months period from {1} to {2}", CalculateDifference(firstMonth, secondMonth), firstMonth, secondMonth);
        }

        static int CalculateDifference(string firstMonth, string secondMonth)
        {
            int firstMonthIndex = 0;
            int secondMonthIndex = 0;

            for (int i = 0; i < months.Count; i++)
            {
                if (firstMonth == months[i])
                {
                    firstMonthIndex = i;
                }
            }

            for (int i = 0; i < months.Count; i++)
            {
                if (secondMonth == months[i])
                {
                    secondMonthIndex = i;
                }
            }
            int result = Math.Abs(firstMonthIndex - secondMonthIndex);

            return result;
        }
    }
}
