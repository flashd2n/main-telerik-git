using System;

namespace ageCalculatorTwo
{
    class ageCalc
    {
        static void Main(string[] args)
        {

            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            DateTime todaysDate = DateTime.Now;

            if (birthDate.Month <= todaysDate.Month)
            {
                int age = todaysDate.Year - birthDate.Year;
                Console.WriteLine(age);
                Console.WriteLine(age + 10);
            }
            else
            {
                int age = todaysDate.Year - birthDate.Year;
                Console.WriteLine(age - 1);
                Console.WriteLine(age + 9);
            }
        }
    }
}
