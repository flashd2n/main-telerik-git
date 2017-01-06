using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleSevenThree
{
    class Startup
    {
        // Using lambda expressions
        static void PrintNumbersUsingLambda(int[] array)
        {
            var numbers = array.Where(x => (x % 21) == 0);

            Console.WriteLine("---------- Using Lambda expressions ----------");
            Console.WriteLine("Numbers that are divisible by 7 and 3 at the same time are: ");

            foreach (var elemenet in numbers)
            {
                Console.WriteLine(elemenet);
            }

            Console.WriteLine();
        }

        // Using LINQ query
        static void PrintnUmbersUsingLINQ(int[] array)
        {
            var numbers =
                from number in array
                where number % 21 == 0
                select number;

            Console.WriteLine("---------- Using LINQ query ----------");
            Console.WriteLine("Numbers that are divisible by 7 and 3 at the same time are: ");

            foreach (var element in numbers)
            {
                Console.WriteLine(element);
            }
        }

        static void Main(string[] args)
        {
            int[] array = { 1, 2, 5, 3, 19, 8, 6, 441, 20, 21 };

            PrintNumbersUsingLambda(array);
            PrintnUmbersUsingLINQ(array);
        }
    }
}