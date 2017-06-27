using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class Startup
    {
        public static void Main()
        {

            var test = new ArrayList<int>();

            for (int i = 0; i < 4; i++)
            {
                test.Add(i);
            }

            test.Insert(2, 42);

            test[0] = 69;

            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i]);
            }

        }
    }
}
