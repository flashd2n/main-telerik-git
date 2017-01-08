using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTwo
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int fn;
        private string tel;
        private string email;
        private List<int> marks;
        //private int groupNumber;
        private Group group;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int FN
        {
            get { return fn; }
            set { fn = value; }
        }
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public List<int> Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        //public int GroupNumber
        //{
        //    get { return groupNumber; }
        //    set { groupNumber = value; }
        //}
        public Group Group
        {
            get { return group; }
            set { group = value; }
        }



        public Student(string firstName, string lastName, int fn, string tel, string email, List<int> marks, Group group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.Group = group;
        }

        
    }
}
