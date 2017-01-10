using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Tomcat : Cat, ISound
    {
        public Tomcat(string name, double age) : base(name, age, Gender.Male)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("I is tomcat and I miew!");
        }
    }
}
