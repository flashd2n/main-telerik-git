using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Startup
    {
        static void Main()
        {
            var collection = new LinkedList<int>();

            var input = Console.ReadLine();

            while (input != string.Empty)
            {
                var number = int.Parse(input);

                if (collection.First == null || collection.First.Value > number)
                {
                    collection.AddFirst(number);
                }
                else if (collection.Last == null || collection.Last.Value < number)
                {
                    collection.AddLast(number);
                }
                else
                {
                    var prevNode = FindPreviousNode(number, collection);

                    collection.AddAfter(prevNode, number);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", collection));

        }

        private static LinkedListNode<int> FindPreviousNode(int number, LinkedList<int> collection)
        {
            var counter = 0;
            var currentNode = collection.First;

            while (counter < collection.Count)
            {
                var nextNode = currentNode.Next;

                if (number > currentNode.Value && number < nextNode.Value)
                {
                    return currentNode;
                }

                currentNode = nextNode;

                ++counter;
            }

            throw new ArgumentException("Node not found");
        }

    }
}
