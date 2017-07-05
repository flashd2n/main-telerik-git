using System;
using System.Collections.Generic;

namespace Task10
{
    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            LinkedList<int> firstList = new LinkedList<int>();
            firstList.AddLast(n);

            Queue<LinkedList<int>> solutions = new Queue<LinkedList<int>>();
            solutions.Enqueue(firstList);

            int m = int.Parse(Console.ReadLine());

            LinkedList<int> result = FindMinOperations(solutions, m);

            PrintResult(result);

        }

        private static LinkedList<int> FindMinOperations(Queue<LinkedList<int>> queueList, int M)
        {
            while (true)
            {
                LinkedList<int> currentList = queueList.Dequeue();
                LinkedListNode<int> currentLastElement = currentList.Last;

                int firstNextValue = currentLastElement.Value + 1;
                LinkedList<int> firstNextList = new LinkedList<int>(currentList);
                firstNextList.AddLast(firstNextValue);

                if (firstNextValue < M)
                {
                    queueList.Enqueue(firstNextList);
                }
                else if (firstNextValue == M)
                {
                    queueList.Enqueue(firstNextList);
                    return firstNextList;
                }

                int secondNextValue = currentLastElement.Value + 2;
                LinkedList<int> secondNextList = new LinkedList<int>(currentList);
                secondNextList.AddLast(secondNextValue);

                if (secondNextValue < M)
                {
                    queueList.Enqueue(secondNextList);
                }
                else if (secondNextValue == M)
                {
                    queueList.Enqueue(secondNextList);
                    return secondNextList;
                }

                int thirdNextValue = currentLastElement.Value * 2;
                LinkedList<int> thirdNextList = new LinkedList<int>(currentList);
                thirdNextList.AddLast(thirdNextValue);

                if (thirdNextValue < M)
                {
                    queueList.Enqueue(thirdNextList);
                }
                else if (thirdNextValue == M)
                {
                    queueList.Enqueue(thirdNextList);
                    return thirdNextList;
                }
            }
        }

        private static void PrintResult(LinkedList<int> result)
        {
            Console.Write("Result: ");
            while (result.Count > 0)
            {
                LinkedListNode<int> tempNode = result.First;
                if (tempNode.Next != null)
                {
                    Console.Write("{0}->", tempNode.Value);
                    result.RemoveFirst();
                }
                else
                {
                    Console.WriteLine("{0}.", tempNode.Value);
                    result.RemoveFirst();
                }
            }
        }
    }
}