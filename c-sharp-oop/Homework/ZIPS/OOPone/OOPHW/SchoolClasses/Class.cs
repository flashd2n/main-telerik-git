using SchoolClasses.Interfaces;
using System.Collections.Generic;

namespace SchoolClasses
{
    class Class : IClass, IComment
    {
        private string textID;
        private List<Teacher> teachers;
        private List<Student> students;
        private List<string> myComments;

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
        public List<string> MyComments
        {
            get { return this.myComments; }
            set { this.myComments = value; }
        }

        public void AddComment(string comment)
        {
            this.MyComments.Add(comment);
        }

        public Class(string textID) : base()
        {
            this.TextID = textID;
            this.MyComments = new List<string>();
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
