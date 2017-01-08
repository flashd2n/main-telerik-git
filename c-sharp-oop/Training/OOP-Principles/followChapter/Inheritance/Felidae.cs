using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Felidae
    {
        private bool male;

        public Felidae() : this (true)
        {
        }
        public Felidae(bool male)
        {
            this.male = male;
        }

        public bool Male
        {
            get { return this.male; }
            set { this.male = value; }
        }

    }
}
