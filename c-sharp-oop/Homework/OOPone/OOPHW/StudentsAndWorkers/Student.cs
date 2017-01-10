using StudentsAndWorkers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    class Student : Human,  IHuman, IStudent
    {
        private double grade;

        public double Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public Student(string firstName, string lastName, double grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

    }
}
