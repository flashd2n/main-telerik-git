using Lists.Queue;
using Lists.Stack;
using System;
using System.Collections.Generic;

namespace Lists
{
    public class Startup
    {
        public static void Main()
        {

            // Custom ArrayList tested and works

            // Custom Doubly Linked List tested and works

            //var primes = Examples.GetPrimes(200, 300);

            //Console.WriteLine(string.Join(" ", primes));

            //var firstList = new List<int>() { 1, 2, 3, 4, 5 };

            //Console.WriteLine($"First List: {string.Join(" ", firstList)}");

            //var secondList = new List<int>() { 2, 4, 6 };

            //Console.WriteLine($"Second List: {string.Join(" ", secondList)}");

            //var union = Examples.Union(firstList, secondList);

            //Console.WriteLine($"Union List: {string.Join(" ", union)}");

            //var intersect = Examples.Intersect(firstList, secondList);

            //Console.WriteLine($"Intersect List: {string.Join(" ", intersect)}");

            var test = new StaticQueue<int>();

            test.Enqueue(1);
            test.Enqueue(2);
            test.Dequeue();
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Dequeue();
            test.Enqueue(6);
            test.Enqueue(7);

            Examples.GetValueIndex(3, 16);

        }
    }
}
