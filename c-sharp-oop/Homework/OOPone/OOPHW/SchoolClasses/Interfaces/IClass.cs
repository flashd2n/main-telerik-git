using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Interfaces
{
    interface IClass
    {
        void AddTeacher(Teacher teacher);
        void AddStudent(Student student);
        List<Teacher> Teachers { get; set; }
        List<Student> Students { get; set; }
    }
}
