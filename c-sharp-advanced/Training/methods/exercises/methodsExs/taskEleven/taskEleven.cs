using System;
using System.Linq;

namespace taskEleven
{
    class taskEleven
    {
        static void Main()
        {
            Console.WriteLine("Choose operation:");
            Console.WriteLine("1 for integer reversal");
            Console.WriteLine("2 for average of sequence of numbers");
            Console.WriteLine("3 for solution of the linear equation: a*x + b = 0");
            byte selection = byte.Parse(Console.ReadLine());

            if (selection == 1)
            {
                Console.WriteLine("Please enter a positive number between 1 and 50,000,000");
                int number = 0;
                bool isValid = int.TryParse(Console.ReadLine(), out number);
                while (number <= 0 || number > 50000000 || !isValid)
                {
                    Console.WriteLine("Please enter a number between 1 and 50,000,000");
                    isValid = int.TryParse(Console.ReadLine(), out number);
                }

                number = ReverseNumber(number);
                Console.WriteLine($"The reversed number is {number}");
            }
            else if (selection == 2)
            {
                Console.WriteLine("Please enter a non-empty sequence of numbers");
                string input = Console.ReadLine();
                while (input == null || input == "")
                {
                    Console.WriteLine("You cannot enter an empty sequence. Try again.");
                    input = Console.ReadLine();
                }
                var sequence = input.Split(' ').Select(int.Parse).ToArray();
                double average = GetAverage(sequence);
                Console.WriteLine($"The average of the sequence is {average}");
            }
            else
            {
                Console.WriteLine("Please enter parameter a (cannot be zero)");
                int a = int.Parse(Console.ReadLine());
                while (a == 0)
                {
                    Console.WriteLine("parameter a cannot be 0. try again");
                    a = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Please enter parameter b");
                int b = int.Parse(Console.ReadLine());
                double result = SolveEquation(a, b);
                Console.WriteLine($"The solution to the equation is: {result}");
            }
        }

        static double SolveEquation(int a, int b)
        {
            double x = ((double)b / a) * (-1);
            return x;
        }

        static double GetAverage(int[] sequence)
        {
            int sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }
            double result = (double)sum / sequence.Length;
            return result;
        }

        static int ReverseNumber(int number)
        {
            string numberString = number.ToString();
            string reversed = null;
            for (int i = 0; i < numberString.Length; i++)
            {
                reversed = numberString[i] + reversed;
            }
            int result = int.Parse(reversed);
            return result;
        }
    }
}
