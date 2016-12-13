using System;

namespace taskOne
{
    class taskOne
    {
        static void Main()
        {
            string name = Console.ReadLine();
            PrintHello(name);
        }

        static void PrintHello(string name)
        {
            Console.WriteLine("{0}{1}!", "Hello, ", name);
        }
    }
}
