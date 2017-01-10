using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class Student : People
    {
        private readonly int classNum;
        private static int count = 1;

        public int ClassNum
        {
            get { return classNum; }
        }

        public Student(string name) : base(name)
        {
            this.classNum = count;
            ++count;
        }

    }
}
