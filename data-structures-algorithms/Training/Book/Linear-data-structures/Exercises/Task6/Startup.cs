using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Startup
    {
        static void Main()
        {

            var input = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var collection = new Dictionary<int, int>();

            var result = GetOnlyEvenOccurences(input);

            Console.WriteLine(string.Join(" ", result));

        }

        public static List<int> GetOnlyEvenOccurences(int[] input)
        {
            var collection = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (collection.ContainsKey(input[i]))
                {
                    ++collection[input[i]];

                }
                else
                {
                    collection[input[i]] = 1;
                }

            }

            var result = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (collection[input[i]] % 2 == 0)
                {
                    result.Add(input[i]);
                }

            }

            return result;
        }
    }
}
