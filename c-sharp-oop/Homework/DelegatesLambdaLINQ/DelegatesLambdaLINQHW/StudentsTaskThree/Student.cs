using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTaskThree
{
    public class Student
    {
        // Fields
        private string firstName;
        private string lastName;
        private string groupName;

        // Constructor
        public Student(string firstName, string lastName, string groupName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.groupName = groupName;
        }

        // Properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First name cannot be null!");
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
                    throw new ArgumentNullException("Last name cannot be null!");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string GroupName
        {
            get { return this.groupName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Group name cannot be null!");
                }
                else
                {
                    this.groupName = value;
                }
            }
        }
    }
}