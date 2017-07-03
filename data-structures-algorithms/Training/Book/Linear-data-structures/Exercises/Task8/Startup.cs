using System;
using System.Collections.Generic;

namespace Task8
{
    public class Startup
    {
        static void Main()
        {
            var input = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            
            try
            {
                var result = GetMajorant(input);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int GetMajorant(int[] input)
        {
            double arrLength = input.Length;

            var majorantCount = (int)Math.Round(arrLength / 2) + 1;

            var countTracker = new Dictionary<int, int>();

            for (int i = 0; i < arrLength; i++)
            {
                if (countTracker.ContainsKey(input[i]))
                {
                    ++countTracker[input[i]];

                    if (countTracker[input[i]] >= majorantCount )
                    {
                        return input[i];
                    }

                }
                else
                {
                    countTracker[input[i]] = 1;
                }

            }

            throw new Exception("The majorant does not exist!");
        }
    }
}
