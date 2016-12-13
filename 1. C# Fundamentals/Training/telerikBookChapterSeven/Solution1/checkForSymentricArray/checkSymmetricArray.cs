using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkForSymentricArray
{
    class checkSymmetricArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            bool symmetry = true;

            for (int i = 0; i < (n / 2); i++)
            {
                if (array[i] != array[n - 1 - i])
                {
                    symmetry = false;
                    break;
                }
            }

            Console.WriteLine("The array is symmetric? {0}", symmetry);

        }
    }
}
