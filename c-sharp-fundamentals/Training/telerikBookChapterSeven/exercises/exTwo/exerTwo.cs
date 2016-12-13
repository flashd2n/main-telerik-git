using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTwo
{
    class exerTwo
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int[] arrayOne = new int[n];

            for (int i = 0; i < n; i++)
            {
                arrayOne[i] = int.Parse(Console.ReadLine());
            }



            int[] arrayTwo = new int[n];

            for (int i = 0; i < n; i++)
            {
                arrayTwo[i] = int.Parse(Console.ReadLine());
            }

            bool isEqual = true;

            if (arrayOne.Length == arrayTwo.Length)
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] != arrayTwo[i])
                    {
                        isEqual = false;
                        break;
                    }
                }
            }
            else
            {
                isEqual = false;
            }

            if (isEqual == true)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }

        }
    }
}
