using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTaskTwo
{
    public class Student
    {
        // Fields
        private string firstName;
        private string lastName;
        private string fn;
        private string telephone;
        private string email;
        private List<int> marks;
        private Group groupNumber;

        // Constructor
        public Student(string firstName, string lastName, string fn, string telephone, string email, List<int> marks, Group groupNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fn = fn;
            this.telephone = telephone;
            this.email = email;
            this.marks = marks;
            this.groupNumber = groupNumber;
        }

        // Properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("First name cannot be null!");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Last name cannot be null!");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string FN
        {
            get { return this.fn; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("FN cannot be null!");
                }
                else
                {
                    this.fn = value;
                }
            }
        }

        public string Telephone
        {
            get { return this.telephone; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Telephone cannot be null!");
                }
                else
                {
                    this.telephone = value;
                }
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Email cannot be null!");
                }
                else
                {
                    this.email = value;
                }
            }
        }

        public List<int> Marks
        {
            get { return this.marks; }
        }

        public Group GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                this.groupNumber = value;
            }
        }
    }
}