using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace followChapter
{
    class Lion : BigCat
    {
        private int weight;

        public Lion() : this (default(int), default(bool))
        {
        }
        public Lion(int weight, bool male) : base(male)
        {
            this.Weight = weight;
        }



        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }
}
