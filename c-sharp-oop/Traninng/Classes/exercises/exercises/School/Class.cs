using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Class
    {
        private string identifier;
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();

        public Class(string identifier)
        {
            this.identifier = identifier;
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }
            set
            {
                this.identifier = value;
            }
        }
        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }
        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"My class is called: {this.Identifier}");
            Console.WriteLine($"There are {students.Count} students in the class:");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].Name} with ID: {students[i].Id}");
            }

            Console.WriteLine($"There are {teachers.Count} teachers in the class:");

            for (int i = 0; i < teachers.Count; i++)
            {
                teachers[i].PrintInfo();
            }

        }

    }
}
