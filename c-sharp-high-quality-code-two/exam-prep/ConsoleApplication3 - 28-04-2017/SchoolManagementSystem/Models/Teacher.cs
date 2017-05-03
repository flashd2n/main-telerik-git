using SchoolManagementSystem.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SchoolManagementSystem
{
    internal class Teacher
    {
        private const int MinStringLength = 2;
        private const int MaxStringLength = 31;
        private const int MaxNumberOfMarksPerStudent = 20;
        private string firstName;
        private string lastName;
        private Subject subject;

        public Teacher(string firstName, string lastName, Subject subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateString(value, MinStringLength, MaxStringLength, "The teacher's first name is not valid");
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
                this.ValidateString(value, MinStringLength, MaxStringLength, "The teacher's last name is not valid");
                this.lastName = value;
            }
        }

        public Subject Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }

        public void AddMark(Student studentToReceiveMark, IMark mark)
        {
            var studentTotalMarks = studentToReceiveMark.Marks.Count;

            if (studentTotalMarks >= MaxNumberOfMarksPerStudent)
            {
                throw new ArgumentException($"Cannot add mark, because the student already has {MaxNumberOfMarksPerStudent} marks");
            }

            studentToReceiveMark.Marks.Add(mark);
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
