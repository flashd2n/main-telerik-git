using System;
using System.Collections.Generic;

namespace Task2
{
    public class Startup
    {
        static void Main()
        {

            var n = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());

                myStack.Push(number);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(myStack.Pop());
            }

        }
    }
}
