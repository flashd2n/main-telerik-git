using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Student
    {
        private string name;
        private int id;
        private static int peopleInclass = 0;

        public Student(string name)
        {
            this.Name = name;
            this.id = ++peopleInclass;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Id
        {
            get
            {
                return this.id;
            }
        }

    }
}
