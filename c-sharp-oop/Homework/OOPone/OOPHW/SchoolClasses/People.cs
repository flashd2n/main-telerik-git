using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class People : Comment
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public People(string name) : base()
        {
            this.Name = name;
        }

    }
}
