using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask
{
    class Student
    {
        private string fullName;
        private string course;
        private string subject;
        private string university;
        private string email;
        private string phoneNumber;
        private static int numberOfStudents = 0;

        public Student() : this (null)
        {
        }
        public Student(string fullName) : this (fullName, null)
        {
        }
        public Student(string fullName, string course) : this (fullName, course, null)
        {

        }
        public Student(string fullName, string course, string subject) : this (fullName, course, subject, null)
        {

        }
        public Student(string fullName, string course, string subject, string university) : this(fullName, course, subject, university, null)
        {

        }
        public Student(string fullName, string course, string subject, string university, string email) : this(fullName, course, subject, university, email, null)
        {

        }
        public Student(string fullName, string course, string subject, string university, string email, string phoneNumber)
        {
            this.FullName = fullName;
            this.Course = course;
            this.Subject = subject;
            this.University = university;
            this.Email = email;
            this.PhoneNumber = phoneNumber;   
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }
        public string Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }
        public string Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                this.subject = value;
            }
        }
        public string University
        {
            get
            {
                return this.university;
            }
            set
            {
                this.university = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }
        public int NumberOfStudents
        {
            get
            {
                return numberOfStudents;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {this.FullName}\nCourse: {this.Course}\nSubject: {this.Subject}\nUniversity: {this.university}\nEmail: {this.Email}\nPhoneNumber: {this.PhoneNumber}");
        }
        
    }
}
