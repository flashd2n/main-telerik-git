using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Student : Person, IStudent
    {
        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public Grade Grade { get; set; }

        public IList<IMark> Marks { get; private set; }        
    }
}
