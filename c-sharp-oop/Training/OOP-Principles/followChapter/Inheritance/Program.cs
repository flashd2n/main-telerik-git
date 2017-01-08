using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var newLion = new Lion(true, 34);
            newLion.Male = true;
            Felidae catOne = newLion;
        }
    }
}
