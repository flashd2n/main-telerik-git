using System.Linq;
using System.Collections.Generic;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem
{
    public class Student
    {
        private const int MinStringLength = 2;
        private const int MaxStringLength = 31;
        private string firstName;
        private string lastName;
        private Grade grade;
        private ICollection<IMark> marks;
        private IValidator validator;

        public Student(string firstName, string lastName, Grade grade, IValidator validator)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
            this.validator = validator;
            this.Marks = new List<IMark>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                validator.ValidateString(value, MinStringLength, MaxStringLength, "The student's first name is not valid");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                validator.ValidateString(value, MinStringLength, MaxStringLength, "The student's last name is not valid");
                this.lastName = value;
            }
        }
        
        public Grade Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public ICollection<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                this.marks = value;
            }
        }

        public string ListMarks()
        {
            var allMarks = this.Marks
                .Select(mark => $"{mark.MarkSubject} => {mark.MarkValue}")
                .ToList();

            var result = string.Join("\n", allMarks);

            return result;
        }
    }
}
