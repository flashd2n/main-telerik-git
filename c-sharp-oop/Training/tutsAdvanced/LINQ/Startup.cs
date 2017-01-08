using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Startup
    {
        static void Main()
        {
            var sample = "I am following the online video course!";

            var result = from p in sample.ToLower()
                         where p == 'a' || p == 'e' || p == 'i' || p == 'o' || p == 'u'
                         orderby p descending
                         group p by p;

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"\t{item.Count()}");
            }
            

        }
    }
}
