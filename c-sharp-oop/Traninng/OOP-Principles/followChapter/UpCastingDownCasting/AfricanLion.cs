using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCastingDownCasting
{
    class AfricanLion : Lion
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public AfricanLion(string name, int age) : base()
        {
            this.Name = name;
            this.Age = age;
        }

        public void MakeNoise()
        {
            Console.WriteLine("made noise");

        }
    }
}
