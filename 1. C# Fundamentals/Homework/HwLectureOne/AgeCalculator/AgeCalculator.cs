using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculator
{
    class AgeCalculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DateTime birthDate;
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    TimeSpan age = DateTime.Now - birthDate;
                    Console.WriteLine("Your age: {0} years and {1} days", (int)(age.Days / 365.25), age.Days % 365.25);
                }
                else
                    Console.WriteLine("You have entered an invalid date." + Environment.NewLine);
            }

        }
    }
}
