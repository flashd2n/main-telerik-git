using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    public static class QuicksortAlgorithmTester
    {
        public static void QuicksortAlgorithm<T>(T[] integerArray, int leftStartIndex, int rightStartIndex)
            where T : IComparable
        {
            int leftCurrentIndex = leftStartIndex;
            int rightCurrentIndex = rightStartIndex;
            T pivotElement = integerArray[(leftStartIndex + rightStartIndex) / 2];

            while (leftCurrentIndex <= rightCurrentIndex)
            {
                while (integerArray[leftCurrentIndex].CompareTo(pivotElement) < 0)
                {
                    leftCurrentIndex++;
                }

                while (integerArray[rightCurrentIndex].CompareTo(pivotElement) > 0)
                {
                    rightCurrentIndex--;
                }

                // Swap elements
                if (leftCurrentIndex <= rightCurrentIndex)
                {
                    T tempElement = integerArray[leftCurrentIndex];
                    integerArray[leftCurrentIndex] = integerArray[rightCurrentIndex];
                    integerArray[rightCurrentIndex] = tempElement;

                    leftCurrentIndex++;
                    rightCurrentIndex--;
                }
            }

            // To the left part of the current array
            if (leftStartIndex < rightCurrentIndex)
            {
                QuicksortAlgorithm(integerArray, leftStartIndex, rightCurrentIndex);
            }

            // To the right part of the current array
            if (leftCurrentIndex < rightStartIndex)
            {
                QuicksortAlgorithm(integerArray, leftCurrentIndex, rightStartIndex);
            }
        }
    }
}
