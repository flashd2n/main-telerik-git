using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FencePaint
{
    class Program
    {
        static void Main()
        {
            // fence -> number of posts
            // colors -> available colors
            // no more than 2 adjanced colors
            Console.WriteLine(fenceColors(3, 2));
            Console.WriteLine(countWays(3, 2));
        }

        static int fenceColors(int fence, int colors)
        {
            if (fence <= 0)
            {
                return 0;
            }
            if (fence <= 2)
            {
                return (int)Math.Pow(colors, fence);
            }
            int sum = 0;
            sum += (colors - 1) * fenceColors(fence - 2, colors);
            sum += (colors - 1) * fenceColors(fence - 1, colors);
            return sum;
        }

        static long countWays(int n, int k)
        {
            // There are k ways to color first post
            long total = k;

            // There are 0 ways for single post to
            // violate (same color_ and k ways to
            // not violate (different color)
            long same = 0;
            long diff = k;

            // Fill for 2 posts onwards
            for (int i = 2; i <= n; i++)
            {
                // Current same is same as previous diff
                same = diff;

                // We always have k-1 choices for next post
                diff = total * (k - 1);

                // Total choices till i.
                total = (same + diff);
            }

            return total;
        }
    }
}
