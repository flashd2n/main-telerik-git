using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares
{
    class Startup
    {
        static void Main()
        {

            Console.WriteLine(fenceColors(3, 2));

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
    }
}
