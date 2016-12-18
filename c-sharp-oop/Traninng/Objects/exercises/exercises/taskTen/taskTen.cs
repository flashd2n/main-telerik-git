using System;
using System.Linq;

namespace taskTen
{
    class taskTen
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }
            Console.WriteLine(sum);
        }
    }
}
