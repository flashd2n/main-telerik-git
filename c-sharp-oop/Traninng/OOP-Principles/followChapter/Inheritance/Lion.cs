using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Lion : Felidae, Reproducible<Lion>
    {
        private int weight;

        public Lion(bool male, int weight) : base(male)
        {
            this.weight = weight;
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        Lion[] Reproducible<Lion>.Reproduce(Lion mate)
        {
            return new Lion[] { new Lion(true, 12), new Lion(false, 10) };
        }
    }
}
