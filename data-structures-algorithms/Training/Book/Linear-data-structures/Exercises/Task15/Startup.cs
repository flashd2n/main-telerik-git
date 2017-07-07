using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    public class Startup
    {
        static void Main(string[] args)
        {

            var testList = new DynamicLinkedList<int>();

            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var value = rnd.Next() % 100;

                testList.Add(value);
            }

            Console.WriteLine(string.Join(", ", testList));

            testList.BubbleSort();

            Console.WriteLine(string.Join(", ", testList));

        }
    }
}
