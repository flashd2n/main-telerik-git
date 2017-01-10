using SchoolClasses.Interfaces;
using System.Collections.Generic;

namespace SchoolClasses
{
    class Class : Comment, IClass
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
