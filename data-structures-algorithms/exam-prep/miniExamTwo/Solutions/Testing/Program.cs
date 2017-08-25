using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static HashSet<long> tree = new HashSet<long>();

        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            List<long> numbersAsString = Console.ReadLine().Split(' ').Select(Int64.Parse).ToList<long>(); ;
            HashSet<long> numbers = new HashSet<long>();

            for (int k = 0; k < numbersAsString.Count; k++)
            {
                numbers.Add(numbersAsString[k]);
            }

            long maxNum = numbers.Max();
            tree.Add(1);
            GenerateTree(maxNum, 1, p);

            int[] result = new int[numbers.Count];
            int i = 0;

            foreach (var number in numbers)
            {
                int counter = 0;

                foreach (var numInHashSet in tree)
                {
                    if (tree.Contains(number - numInHashSet))
                    {
                        counter++;
                    }
                }

                if (counter == 2)
                {
                    result[i] = 1;
                    i++;
                }

                else
                {
                    result[i] = 0;
                    i++;
                }
            }

            Console.WriteLine(string.Join(" ", result));

        }
        static void GenerateTree(long max, long current, int p)
        {
            if (current >= max)
            {
                return;
            }

            long leftChild = p * current;
            var rightChild = leftChild + 1;

            tree.Add(leftChild);
            GenerateTree(max, leftChild, p);

            tree.Add(rightChild);
            GenerateTree(max, rightChild, p);
        }
    }
}
