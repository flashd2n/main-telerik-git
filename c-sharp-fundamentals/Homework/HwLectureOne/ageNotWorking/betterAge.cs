﻿using System;

namespace ageNotWorking
{
    class betterAge
    {
        static void Main(string[] args)
        {
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            DateTime todaysDate = DateTime.Now;

            if (birthDate.Month < todaysDate.Month)
            {
                int age = todaysDate.Year - birthDate.Year;
                Console.WriteLine(age);
                Console.WriteLine(age + 10);
            }


            if (birthDate.Month > todaysDate.Month)
            {
                int age = todaysDate.Year - birthDate.Year;
                Console.WriteLine(age - 1);
                Console.WriteLine(age + 9);
            }

            if (birthDate.Month == todaysDate.Month)
            {
                if (birthDate.Day < todaysDate.Day)
                {
                    int age = todaysDate.Year - birthDate.Year;
                    Console.WriteLine(age);
                    Console.WriteLine(age + 10);
                }
                if (birthDate.Day > todaysDate.Day)
                {
                    int age = todaysDate.Year - birthDate.Year;
                    Console.WriteLine(age - 1);
                    Console.WriteLine(age + 9);
                }
                if (birthDate.Day == todaysDate.Day)
                {
                    Console.WriteLine("What time of the day were you born?");
                }
            }
        }
    }
}
