using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibo
{
    public class Startup
    {
        static void Main()
        {

            Console.WriteLine(GetFibonacci(19));

        }

        public static int GetFibonacci(int num)
        {
            var nums = new int[num + 1];

            return GetFibonacci(num, nums);
        }

        public static int GetFibonacci(int num, int[] nums)
        {
            if (num <= 2)
            {
                return 1;
            }

            var fibo = 0;

            if (nums[num] == 0)
            {
                fibo = GetFibonacci(num - 1, nums) + GetFibonacci(num - 2, nums);

                nums[num] = fibo;
            }
            else
            {
                fibo = nums[num];
            }

            return fibo;

        }

    }
}
