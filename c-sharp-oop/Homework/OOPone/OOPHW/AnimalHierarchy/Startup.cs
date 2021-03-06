﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Startup
    {
        static void Main()
        {
            

            var cats = new Cat[]
            {
                new Kitten("mariika", 4.3),
                new Tomcat("invacho", 4.4)
            };

            var allAnimals = new Animal[]
            {
                new Dog("berg", 9, Gender.Male),
                new Frog("gosho", 1.2, Gender.Female),
                new Kitten("mariika", 2.3),
                new Tomcat("invacho", 3),
                new Dog("Rex", 4, Gender.Male),
                new Frog("tosho", 3.2, Gender.Female),
                new Kitten("ivanka", 5.4),
                new Tomcat("mariancho", 2)
            };

            Console.WriteLine($"The average age of my cats array is: {CalculateAverageAge(cats)}");
            Console.WriteLine($"The average age of all animals array is: {CalculateAverageAge(allAnimals)}");

            Console.WriteLine("\nSAME WITH LINQ");
            Console.WriteLine($"The average age of my cats array is: {CalculateAverageAgeLINQ(cats)}");
            Console.WriteLine($"The average age of all animals array is: {CalculateAverageAgeLINQ(allAnimals)}");

            Console.WriteLine("\nAverage age per animal type in the array with all animals with LINQ GROUPING");

            var result = from animal in allAnimals
                         group animal by animal.GetType().Name;

            foreach (var group in result)
            {
                Console.WriteLine($"{group.Key} -> {CalculateAverageAgeThree(group)}");
            }

        }


        public static double CalculateAverageAge(Animal[] array)
        {
            double result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i].Age;
            }

            return result / array.Length;
        }

        public static double CalculateAverageAgeLINQ(Animal[] array)
        {
            double result = 0;

            var ages = from item in array
                       select item.Age;

            foreach (var age in ages)
            {
                result += age;
            }

            return result / array.Length;
        }

        public static double CalculateAverageAgeThree(IGrouping<string, Animal> array)
        {
            double result = 0;

            var ages = from item in array
                       select item.Age;

            foreach (var age in ages)
            {
                result += age;
            }

            return result / array.Count();
        }

    }
}
