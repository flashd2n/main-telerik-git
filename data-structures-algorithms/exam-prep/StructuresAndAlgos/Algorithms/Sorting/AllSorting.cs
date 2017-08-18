using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public static class AllSorting
    {
        public static int[] CustomQuickSort(this int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            var pivot = array[0]; // try to find the average value for the pivot to avoid worst case scenarios
            var left = new List<int>();
            var right = new List<int>();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < pivot)
                {
                    left.Add(array[i]);
                }
                else
                {
                    right.Add(array[i]);
                }
            }

            var leftA = left.ToArray().CustomQuickSort();
            var rifhtA = right.ToArray().CustomQuickSort();

            var result = new List<int>(leftA);
            result.Add(pivot);
            result.AddRange(rifhtA);

            return result.ToArray();
        }

        public static void QuickSortInPlace(this int[] array)
        {
            array.QuickSortInPlace(0, array.Length - 1);
        }

        public static void QuickSortInPlace(this int[] array, int left, int right)
        {
            if (left < right)
            {
                var pivot = array.LomutoPartition(left, right);
                array.QuickSortInPlace(left, pivot - 1);
                array.QuickSortInPlace(pivot + 1, right);
            }
        }

        public static int LomutoPartition(this int[] array, int low, int high)
        {
            var pivot = array[high];

            var i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    ++i;
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            if (array[high] < array[i + 1])
            {
                var temp = array[i + 1];
                array[i + 1] = array[high];
                array[high] = temp;
            }

            return i + 1;
        }

        public static void CustomMergeSort(this int[] array)
        {
            array.CustomMergeSort(0, array.Length);
        }

        public static void CustomMergeSort(this int[] array, int left, int right)
        {
            if (right - left <= 1)
            {
                return;
            }

            var middle = (right + left) / 2;
            array.CustomMergeSort(left, middle);
            array.CustomMergeSort(middle, right);
            array.Merge(left, middle, right);
        }

        public static void MergeSortIterative(this int[] array)
        {
            for (int half = 1; half < array.Length; half *= 2)
            {
                for (int left = 0; left < array.Length; left += half * 2)
                {
                    var middle = left + half;
                    if (middle >= array.Length)
                    {
                        break;
                    }
                    var right = left + half * 2;
                    if (right > array.Length)
                    {
                        right = array.Length;
                    }

                    array.Merge(left, middle, right);

                    Console.WriteLine($"LEFT: {left} | MIDDLE: {middle} | RIGHT: {right}");
                }
            }
        }

        public static void Merge(this int[] array, int left, int middle, int right)
        {
            var leftSize = middle - left;
            var rightSize = right - middle;

            var leftArray = new int[leftSize];
            var rightArray = new int[rightSize];

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
                if (leftArray[leftIndex] < rightArray[rightIndex])
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

        public static void CountingSort(this int[] array, int maxNum, int minNum = 0)
        {
            var counts = new int[maxNum + 1 - minNum];

            foreach (var element in array)
            {
                ++counts[element - minNum];
            }

            var index = 0;

            for (int i = 0; i < counts.Length; i++)
            {
                for (int j = 0; j < counts[i]; j++)
                {
                    array[index] = i + minNum;
                    ++index;
                }
            }
        }

        public static void BucketSort(this int[] array, int digits, int basePower)
        {
            var list = new List<int>(array);
            list.BucketSort(digits, basePower);
            list.CopyTo(array, 0);
        }

        private static void BucketSort(this List<int> array, int digits, int basePower)
        {
            if (digits < 0)
            {
                return;
            }

            var digitPower = 1;

            for (int i = 0; i < digits; i++)
            {
                digitPower *= basePower;
            }

            var buckets = new List<List<int>>();

            for (int i = 0; i < 10; i++)
            {
                buckets.Add(new List<int>());
            }

            foreach (var num in array)
            {
                var digit = (num / digitPower) % basePower;

                buckets[digit].Add(num);
            }

            foreach (var bucket in buckets)
            {
                bucket.BucketSort(digits - 1, basePower);
            }

            array.Clear();

            foreach (var bucket in buckets)
            {
                array.AddRange(bucket);
            }
        }

        public static void RadixSort(this int[] array, int digits, int basePower)
        {
            var buckets = new List<List<int>>();

            for (int i = 0; i < 10; i++)
            {
                buckets.Add(new List<int>());
            }

            var digitPower = 1;

            for (int i = 0; i < digits; i++)
            {
                foreach (var num in array)
                {
                    var digit = (num / digitPower) % basePower;

                    buckets[digit].Add(num);
                }

                var index = 0;

                foreach (var bucket in buckets)
                {
                    foreach (var el in bucket)
                    {
                        array[index] = el;
                        ++index;
                    }
                    bucket.Clear();
                }

                digitPower *= basePower;
            }
        }
    }
}
