using System;

namespace intDoubleString
{
    class intDoubleStr
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (input == "integer")
            {
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine(++a);
            }
            else if (input == "real")
            {
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:F2}", ++b);
            }
            else if (input == "text")
            {
                string text = Console.ReadLine();
                Console.WriteLine("{0}*", text);
            }
            else
            {
                Console.WriteLine("not a valid input");
            }
        }
    }
}
