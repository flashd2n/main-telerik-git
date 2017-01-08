using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedShelter
{
    class Startup
    {
        static void Main()
        {
            var dogShelter = new AnimalShelter<Dog>(5);
            var carShelter = new AnimalShelter<Cat>(5);



        }
    }
}
