using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCastingDownCasting
{
    class Animal
    {
        public int NumberLegs { get; set; }
        public Animal()
        {

        }
        protected string MakeSound()
        {
            return "I made sound";
        }
        public void Something()
        {
            this.MakeSound();
        }
    }
}
