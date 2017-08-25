using System;
using System.Collections.Generic;

namespace JediMeditation
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var allJedi = Console.ReadLine().Split(' ');

            //var result = new List<string>();

            //for (int i = 0; i < n; i++)
            //{
            //    if (allJedi[i][0] == 'M')
            //    {
            //        result.Add(allJedi[i]);
            //        continue;
            //    }
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    if (allJedi[i][0] == 'K')
            //    {
            //        result.Add(allJedi[i]);
            //        continue;
            //    }
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    if (allJedi[i][0] == 'P')
            //    {
            //        result.Add(allJedi[i]);
            //        continue;
            //    }
            //}

            CustomMergeSort(allJedi);

            Console.WriteLine(string.Join(" ", allJedi));
        }
        public static void CustomMergeSort(string[] array)
        {
            CustomMergeSort(array, 0, array.Length);
        }

        public static void CustomMergeSort(string[] array, int left, int right)
        {
            if (right - left <= 1)
            {
                return;
            }

            var middle = (right + left) / 2;
            CustomMergeSort(array, left, middle);
            CustomMergeSort(array, middle, right);
            Merge(array, left, middle, right);
        }

        public static void Merge(string[] array, int left, int middle, int right)
        {
            var leftSize = middle - left;
            var rightSize = right - middle;

            var leftArray = new string[leftSize];
            var rightArray = new string[rightSize];

            for (int i = 0; i < leftSize; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (int i = 0; i < rightSize; i++)
            {
                rightArray[i] = array[middle + i];
            }

            var leftIndex = 0;
            var rightIndex = 0;
            var mainIndex = left;

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                var leftType = GetType((int)leftArray[leftIndex][0]);
                var rightType = GetType((int)rightArray[rightIndex][0]);

                // HERE CAN ADD CHECK FOR JEDI RANK

                if (leftType <= rightType)
                {
                    array[mainIndex] = leftArray[leftIndex];
                    ++leftIndex;
                }
                else
                {
                    array[mainIndex] = rightArray[rightIndex];
                    ++rightIndex;
                }
                ++mainIndex;
            }

            while (leftIndex < leftSize)
            {
                array[mainIndex] = leftArray[leftIndex];
                ++leftIndex;
                ++mainIndex;
            }

            while (rightIndex < rightSize)
            {
                array[mainIndex] = rightArray[rightIndex];
                ++rightIndex;
                ++mainIndex;
            }
        }

        private static int GetType(int v)
        {
            if (v == 77)
            {
                return 1;
            }
            else if (v == 75)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
