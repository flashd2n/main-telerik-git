using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Startup
    {
        static void Main()
        {
            var testing = new GenericList<int>(4);
            testing.Add(3);
            testing.Add(4);
            testing.Add(5);

            //testing.RemoveByIndex(1);

            //testing.InsertItem(1, 49);
            //testing.InsertItem(0, 55);

            //testing.RemoveByIndex(3);

            //testing.Clear();

            //Console.WriteLine(testing.IndexOf(49));

            testing.Add(6);
            testing.InsertItem(1, 49);


            testing.Print();
            Console.WriteLine(testing.Count);
            Console.WriteLine(testing.Capacity);
        }
    }
}
