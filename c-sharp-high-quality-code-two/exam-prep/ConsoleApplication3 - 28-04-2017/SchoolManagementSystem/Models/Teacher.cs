using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using System;

namespace SchoolManagementSystem
{
    internal class Teacher : Person
    {
        private const int MaxNumberOfMarksPerStudent = 20;
        private Subject subject;

        public Teacher(string firstName, string lastName, Subject subject) : base(firstName, lastName)
        {
            this.Subject = subject;
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
    }
}
