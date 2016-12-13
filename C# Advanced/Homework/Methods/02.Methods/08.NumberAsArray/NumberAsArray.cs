using System;
using System.Linq;
using System.Text;

namespace _08.NumberAsArray
{
    class Program
    {
        static void Main(string[] args)
        { 
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[] firstArr = Console.ReadLine().Split(' ').ToArray();
            string[] secondArr = Console.ReadLine().Split(' ').ToArray();

            ReverseAndCalculate(size, firstArr, secondArr);
        }

        static void ReverseAndCalculate(int[] size, string[] firstArr, string[] secondArr)
        {
            StringBuilder sum = new StringBuilder();
            int firstNum = 0;
            int secondNum = 0;
            int increaseWithOne = 0;
            int maxSize = size.Max();
            //calculation
            for (int i = 0; i <= maxSize - 1; i++)
            {
                //first number/array
                if (i <= size[0] - 1)
                {
                    firstNum = int.Parse(firstArr[i]);
                }
                else
                {
                    firstNum = 0;
                }
                //second number/array
                if (i <= size[1] - 1)
                {
                    secondNum = int.Parse(secondArr[i]);
                }
                else
                {
                    secondNum = 0;
                }
                //first + second
                sum.Append(((firstNum + secondNum + increaseWithOne) % 10) + " ");

                if ((firstNum + secondNum + increaseWithOne) > 9)
                {
                    increaseWithOne = 1;
                }
                else
                {
                    increaseWithOne = 0;
                }
            }
            //print
            Console.WriteLine(sum);
        }
    }
}