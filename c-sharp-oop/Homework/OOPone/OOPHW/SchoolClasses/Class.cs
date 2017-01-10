using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class Class : Comment
    {
        private string textID;
        private List<Teacher> teachers;
        private List<Student> students;

        public string TextID
        {
            get { return this.textID; }
            set { this.textID = value; }
        }
        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }
        public List<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
        public Class(string textID) : base()
        {
            this.TextID = textID;
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
        }

        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }
        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }
    }
}
