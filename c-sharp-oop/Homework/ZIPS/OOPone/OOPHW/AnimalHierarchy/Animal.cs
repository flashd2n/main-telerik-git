using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Animal
    {
        private string name;
        private double age;
        private Gender sex;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public Gender Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public Animal(string name, double age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }
    }
}
