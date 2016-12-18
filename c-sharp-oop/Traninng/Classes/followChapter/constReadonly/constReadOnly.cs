using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constReadonly
{
    class constReadOnly
    {
        static void Main()
        {
            Console.WriteLine(ConstAndReadonlyExample.PI);
            var instance = new ConstAndReadonlyExample(5);
            var instanceTwo = new ConstAndReadonlyExample(10);


            Console.WriteLine(instance.Size);
            Console.WriteLine(instanceTwo.Size);
        }
    }

    public class ConstAndReadonlyExample
    {
        public const double PI = 3.1415926535897932385;
        public readonly double Size;

        public ConstAndReadonlyExample(int size)
        {
            this.Size = size;
        }
    }
}
