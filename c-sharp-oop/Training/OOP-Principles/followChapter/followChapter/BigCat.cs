using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace followChapter
{
    class BigCat
    {
        private bool male;

        public BigCat() : this (default(bool))
        {
        }

        public BigCat(bool male)
        {
            this.Male = male;
        }

        public bool Male
        {
            get { return this.male; }
            private set { this.male = value; }
        }
    }
}
