using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Frog : Animal, ISound
    {
        public Frog(string name, double age, Gender sex) : base(name, age, sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("I is frog, I do stuff");
        }
    }
}
