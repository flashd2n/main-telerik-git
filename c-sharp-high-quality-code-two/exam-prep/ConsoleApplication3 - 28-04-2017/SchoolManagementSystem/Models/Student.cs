using SchoolManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public Student(string firstName, string lastName, Grade grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
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
                this.ValidateString(value, MinStringLength, MaxStringLength, "The student's first name is not valid");
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
                this.ValidateString(value, MinStringLength, MaxStringLength, "The student's last name is not valid");
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

        private void ValidateString(string textToValidate, int minLength, int maxLength, string errorMessage)
        {
            var textToVallidateLength = textToValidate.Length;

            var isInvalidLength = textToVallidateLength < minLength || textToVallidateLength > maxLength;
            var hasNonLatinChars = !Regex.IsMatch(textToValidate, @"^[a-zA-Z]+$");

            if (isInvalidLength || hasNonLatinChars)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
