using System;

namespace passingArguments
{
    class Program
    {


        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            ChangeParameter(input);

            Console.WriteLine("Main Method input: " + input);
        }

        static void ChangeParameter(int input)
        {
            input = 5;

            Console.WriteLine("New Method input: " + input);

        }


    }
}
