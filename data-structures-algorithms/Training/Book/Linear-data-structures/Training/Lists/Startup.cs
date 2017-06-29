using System;

namespace Lists
{
    public class Startup
    {
        public static void Main()
        {

            // ArrayList tested and works

            var test = new DoublyLinkedList<int>();

            for (int i = 0; i < 20; i++)
            {
                test.Add(i);
            }

            for (int i = 0; i < test.Count; i++)
            {
                Console.Write(test[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
