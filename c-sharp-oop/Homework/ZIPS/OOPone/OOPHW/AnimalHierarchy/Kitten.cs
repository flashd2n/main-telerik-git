using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Kitten : Cat, ISound
    {
        public Kitten(string name, double age) : base(name, age, Gender.Female)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("I am kitten and I miew!");
        }

    }
}
