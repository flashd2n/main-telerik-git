using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Startup
    {
        static void Main()
        {
            var tower = new ClockTower();
            var myPerson = new Person("gosho", tower);


            tower.ChimeSixAM();
            tower.ChimeFivePM();
        }
    }
}
