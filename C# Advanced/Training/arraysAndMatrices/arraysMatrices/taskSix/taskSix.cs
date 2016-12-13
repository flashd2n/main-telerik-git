using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskSix
{
    class taskSix
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<int> array = input.Split(' ').Select(int.Parse).ToList();
            var sequences = GetSequences(array, new int[array.Count]);
            int startIndex = GetStartIndex(sequences);
            int lengthMaxSequence = GetLength(sequences);
            var maxIncreasingSubsequence = GetMaxIncrSubsequence(new int[lengthMaxSequence], lengthMaxSequence, sequences, array, startIndex);

            Console.WriteLine(string.Join(", ", maxIncreasingSubsequence));
        }

        static int[] GetMaxIncrSubsequence(int[] v, int lengthMaxSequence, int[] sequences, List<int> array, int startIndex)
        {
            var maxIncreasingSubsequence = new int[lengthMaxSequence];
            int counter = 0;
            int currentBest = 0;

            for (int i = startIndex; i >= 0; i--)
            {
                if (i == startIndex)
                {
                    currentBest = sequences[startIndex];
                    maxIncreasingSubsequence[maxIncreasingSubsequence.Length - 1 - counter] = array[i];
                    ++counter;
                }

                if (sequences[i] == (currentBest - 1))
                {
                    currentBest = sequences[i];
                    maxIncreasingSubsequence[maxIncreasingSubsequence.Length - 1 - counter] = array[i];          
                    ++counter;
                }
            }
            return maxIncreasingSubsequence;
        }

        static int GetStartIndex(int[] sequences)
        {
            int startIndex = -1;
            int bestValue = 0;

            for (int i = 0; i < sequences.Length; i++)
            {
                if (sequences[i] > bestValue)
                {
                    bestValue = sequences[i];
                    startIndex = i;
                }
            }
            return startIndex;
        }


        static int GetLength(int[] sequences)
        {
            int best = 0;

            for (int i = 0; i < sequences.Length; i++)
            {

                if (sequences[i] > best)
                {
                    best = sequences[i];
                }

            }

            return best;
        }

        static int[] GetSequences(List<int> array, int[] sequences)
        {
            for (int i = 0; i < array.Count; i++)
            {
                sequences[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] > array[j])
                    {
                        sequences[i] = Math.Max(sequences[i], (sequences[j] + 1));
                    }
                }
            }
            return sequences;
        }
    }
}
