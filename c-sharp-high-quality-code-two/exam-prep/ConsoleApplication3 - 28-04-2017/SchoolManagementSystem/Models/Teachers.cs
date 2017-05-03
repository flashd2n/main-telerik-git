using SchoolManagementSystem.Interfaces;
using System;

namespace SchoolManagementSystem
{
    class Teachers
    {
        private const int MinStringLength = 2;
        private const int MaxStringLength = 31;
        private const int MaxNumberOfMarksPerStudent = 20;
        private string firstName;
        private string lastName;
        private Subject subject;
        private IValidator validator;

        public Teachers(string firstName, string lastName, Subject subject, IValidator validator)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
            this.validator = validator;
        }
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.validator.ValidateString(value, MinStringLength, MaxStringLength, "The teacher's first name is not valid");
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
                this.validator.ValidateString(value, MinStringLength, MaxStringLength, "The teacher's last name is not valid");
                this.lastName = value;
            }
        }

        public Subject Subject
        {
            get { return subject; }
            set { subject = value; }
        }


        public void AddMark(Student studentToReceiveMark, IMark mark)
        {
            var studentTotalMarks = studentToReceiveMark.Marks.Count;

            if(studentTotalMarks >= MaxNumberOfMarksPerStudent)
            {
                throw new ArgumentException($"Cannot add mark, because the student already has {MaxNumberOfMarksPerStudent} marks");
            }

            studentToReceiveMark.Marks.Add(mark);
        }
    }
}
