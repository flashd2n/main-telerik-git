using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Person
    {
        private string name;
        private ClockTower tower;

        public Person(string name, ClockTower tower)
        {
            this.name = name;
            this.tower = tower;

            this.tower.Chime += (object sender, ClockTowerEventArgs args) =>
            {
                Console.WriteLine($"{this.name}: I heard the tower chime at {args.Time}!");
            };
        }

    }
}
