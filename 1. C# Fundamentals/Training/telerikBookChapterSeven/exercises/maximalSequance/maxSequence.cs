using System;

namespace maximalSequance
{
    class maxSequence
    {
        static void Main()
        {
            /// ------> BGCODER SOLUTION
            
            //int n = int.Parse(Console.ReadLine());
            //int currentCounter = 0;
            //int maxCounter = 0;
            //int[] arrayInt = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    arrayInt[i] = int.Parse(Console.ReadLine());
            //    if (i == 0)
            //    {
            //        continue;
            //    }
            //    if (arrayInt[i] == arrayInt[i - 1])
            //    {
            //        ++currentCounter;

            //        if (currentCounter > maxCounter)
            //        {
            //            maxCounter = currentCounter;
            //        }
            //    }
            //    else
            //    {
            //        currentCounter = 0;
            //    }
            //}
            //Console.WriteLine(maxCounter + 1);

            // ----------------->  Book Exercise 4 -> traverse a sequence and print mini sequances of equal elements

            //int n = int.Parse(Console.ReadLine());
            //int[] arrayInt = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    arrayInt[i] = int.Parse(Console.ReadLine());
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    if (i == 0)
            //    {
            //        if (arrayInt[i] == arrayInt[i + 1])
            //        {
            //            Console.Write("{0} ", arrayInt[i]);
            //        }
            //        continue;
            //    }
            //    else if (i == n - 1)
            //    {
            //        if (arrayInt[i] == arrayInt[i - 1])
            //        {
            //            Console.Write("{0}{1}", arrayInt[i], "\n");
            //        }
            //        break;
            //    }
            //    if ((arrayInt[i] == arrayInt[i + 1]) && (arrayInt[i] != arrayInt[i - 1]))//begin
            //    {
            //        Console.Write("{0} ", arrayInt[i]);
            //    } else if ((arrayInt[i] != arrayInt[i + 1]) && (arrayInt[i] == arrayInt[i - 1])) //end
            //    {
            //        Console.Write("{0}{1}", arrayInt[i], "\n");
            //    }
            //    else if (arrayInt[i] == arrayInt[i - 1]) //middle
            //    {
            //        Console.Write("{0} ", arrayInt[i]);
            //    }
            //}


            // ----------------->  Book Exercise 4   FINALLY DONE IT!!!!!


            int n = int.Parse(Console.ReadLine());
            int currentCounter = 0;
            int maxCounter = 0;
            int bestIndex = 0;
            int[] arrayInt = new int[n];

            for (int i = 0; i < n; i++)
            {
                arrayInt[i] = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    continue;
                }
                if (arrayInt[i] == arrayInt[i - 1])
                {
                    ++currentCounter;

                    if (currentCounter > maxCounter)
                    {
                        maxCounter = currentCounter;
                        bestIndex = i;
                    }
                }
                else
                {
                    currentCounter = 0;
                }
            }

            for (int i = 0; i <= maxCounter; i++)
            {
                Console.Write("{0}{1}", arrayInt[bestIndex - i], i == (maxCounter) ? "\n" : " ");
            }
        }
    }
}
