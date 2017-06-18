using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Startup
    {
        static void Main()
        {

            var array = new int[50];

            for (int i = 0; i < 50; i++)
            {
                array[i] = i;
            }

            var searchedValue = 4;
            var foundPosition = -1;

            var left = 0;
            var right = array.Length - 1;

            do
            {

                var currentIndex = (right + left) / 2;

                if (array[currentIndex] < searchedValue)
                {
                    left = currentIndex;
                }
                else if (array[currentIndex] > searchedValue)
                {
                    right = currentIndex;
                }
                else
                {
                    foundPosition = currentIndex;
                    break;
                }

            } while (left != right);


            Console.WriteLine($"Element found at position: {foundPosition}");
        }
    }
}
