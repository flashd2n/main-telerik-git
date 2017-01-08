using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Startup
    {
        static void Main()
        {
            var disciplineOne = new Disciplines("Math", 4, 4);
            var disciplineTwo = new Disciplines("Literature", 5, 5);
            var disciplineThree = new Disciplines("History", 6, 6);
            var teacherOne = new Teacher("Gosho");
            var teacherTwo = new Teacher("Gosho2");
            var teacherThree = new Teacher("Gosho3");
            teacherOne.AddDiscipline(disciplineOne);
            teacherOne.AddDiscipline(disciplineTwo);
            teacherTwo.AddDiscipline(disciplineThree);
            teacherThree.AddDiscipline(disciplineOne);
            teacherThree.AddDiscipline(disciplineThree);
            var studentOne = new Student("tosho");
            var studentTwo = new Student("penka");
            var studentThree = new Student("stamat");
            var myClass = new Class("The mad class");
            myClass.AddStudent(studentOne);
            myClass.AddStudent(studentTwo);
            myClass.AddStudent(studentThree);
            myClass.AddTeacher(teacherOne);
            myClass.AddTeacher(teacherTwo);
            myClass.AddTeacher(teacherThree);

            myClass.PrintInfo();


        }
    }
}
