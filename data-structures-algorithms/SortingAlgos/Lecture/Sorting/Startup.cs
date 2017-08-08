using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    public class Startup
    {
        static void Main()
        {
            var array = new int[20];
            var rdn = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rdn.Next(0, 100);
            }

            //var output = array.CustomSelectionSort();

            //var output = array.CustomBubbleSort();

            //var output = array.CustomInsertionSort();

            //var output = array.InsertionSortArray();

            //var output = array.CustomQuickSort();

            //array.QuickSortInPlace();

            //Console.WriteLine(string.Join(", ", array));

            //array.QuickSortInPlace();

            array.RadixSort(2, 10);

            Console.WriteLine(string.Join(", ", array));
        }        
    }
}
