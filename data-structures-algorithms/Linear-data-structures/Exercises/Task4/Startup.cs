using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class Startup
    {
        static void Main()
        {
            var input = new List<int>() { 1, 3, 46, 12, 5, 31, 1, 2, 7, 3, 2, 2, 1, 9, 1, 3 };
            var result = GetLongestSubsequenceEqualElements(input);

            Console.WriteLine(string.Join(" ", result));

        }

        public static List<int> GetLongestSubsequenceEqualElements(List<int> input)
        {

            input.Sort();

            int currentCount = 1;
            int currentValue = 0;
            int bestCount = 1;
            int bestValue = 0;

            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1])
                {

                    currentValue = input[i];
                    ++currentCount;

                }
                else
                {

                    if (currentCount > bestCount)
                    {
                        bestCount = currentCount;
                        bestValue = currentValue;
                        
                    }

                    currentCount = 1;
                    currentValue = 0;

                }

                if (i == input.Count - 1)
                {
                    if (currentCount > bestCount)
                    {
                        bestCount = currentCount;
                        currentCount = 1;

                        bestValue = currentValue;
                        currentValue = 0;

                    }
                }

            }

            return new List<int>(Enumerable.Repeat(bestValue, bestCount));
        }
    }
}
