using System;

namespace mixinfNumbers
{
    class mixNums
    {
        static void Main()
        {

            int arrayCount = int.Parse(Console.ReadLine());
            int[] arrayMain = new int[arrayCount];
            int sub = 0;
            int mix = 0;

            for (int i = 0; i < arrayCount; i++)
            {
                arrayMain[i] = int.Parse(Console.ReadLine());
            }
            
            for (int i = 0; i < arrayCount - 1; i++)
            {
                mix = (arrayMain[i] % 10) * (arrayMain[i + 1] / 10);
                Console.Write("{0}{1}", mix, i == arrayCount - 2 ? "\n" : " ");
            }

            for (int i = 0; i < arrayCount - 1; i++)
            {
                sub = arrayMain[i] - arrayMain[i + 1];
                Console.Write("{0}{1}", Math.Abs(sub), i == arrayCount - 2 ? "\n" : " ");             
            }
        }
    }
}
