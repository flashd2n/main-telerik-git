using HashTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class Startup
    {
        static void Main()
        {
            var set = new MyHashSet<int>();
            set.Add(5);
            set.Add(32);
            set.Add(12);
            set.Add(1341);
            set.Add(666);

            set.Remove(666);
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
