using System;
using System.Collections.Generic;

namespace Task9
{
    public class Startup
    {
        static void Main()
        {

            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int>();

            var target = 50;

            queue.Enqueue(n);

            while (target > 0 && queue.Count != 0)
            {
                queue.Enqueue(n + 1);

                queue.Enqueue(2 * n + 1);

                queue.Enqueue(n + 2);

                n = queue.Dequeue();

                Console.Write(n + " ");

                n = queue.Peek();

                --target;
            }

        }
    }
}
