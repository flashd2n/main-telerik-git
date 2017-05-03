using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Commands
{
    internal class CreateStudentCommand
    {
        public static int id = 0;
        public string Execute(IList<string> para)
        {
            Engine.students.Add(id, new Student(para[0], para[1], (Grade)int.Parse(para[2])));
            return $"A new student with name {para[0]} {para[1]}, grade {(Grade)int.Parse(para[2])} and ID {id++} was created.";
        }
    }
}
