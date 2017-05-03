using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem
{
    public class Student : Person
    {
        private Grade grade;
        private ICollection<IMark> marks;

        public Student(string firstName, string lastName, Grade grade) : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
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
            if (this.Marks.Count == 0)
            {
                throw new ArgumentException("This student has no marks.");
            }

            var allMarks = this.Marks
                .Select(mark => $"{mark.MarkSubject} => {mark.MarkValue}")
                .ToList();

            var result = string.Join("\n", allMarks);

            return result;
        }
    }
}
