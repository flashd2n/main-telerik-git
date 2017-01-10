using System;

namespace SchoolClasses
{
    class Startup
    {
        static void Main()
        {
            var studentOne = new Student("Goshko");
            var studentTwo = new Student("Pencho");
            var studentThree = new Student("Stamat");
            var studentFour = new Student("Toshko");
            var studentFive = new Student("Gincho");

            var teacherOne = new Teacher("Alex");
            var teacherTwo = new Teacher("Vic");
            var teacherThree = new Teacher("Ste3v");

            var disciplineOne = new Disciplines("Math", 6, 12);
            var disciplineTwo = new Disciplines("c#", 8, 16);
            var disciplineThree = new Disciplines("JS", 2, 4);

            teacherOne.AddDiscipline(disciplineOne);
            teacherOne.AddDiscipline(disciplineTwo);

            teacherTwo.AddDiscipline(disciplineTwo);
            teacherOne.AddDiscipline(disciplineThree);
            teacherThree.AddDiscipline(disciplineOne);
            teacherThree.AddDiscipline(disciplineThree);

            var myClass = new Class("The most awesome class");
            myClass.AddStudent(studentOne);
            myClass.AddStudent(studentTwo);
            myClass.AddStudent(studentThree);
            myClass.AddStudent(studentFour);
            myClass.AddStudent(studentFive);
            myClass.AddTeacher(teacherOne);
            myClass.AddTeacher(teacherTwo);
            myClass.AddTeacher(teacherThree);

            var mySchool = new School();
            mySchool.AddClass(myClass);


            Console.WriteLine($"My School has a class: {myClass.TextID}");
            Console.WriteLine("The teachers in the class are:");
            foreach (var teacher in myClass.Teachers)
            {
                Console.WriteLine($"\t{teacher.Name} and he teaches:");
                foreach (var discipline in teacher.Disciplines)
                {
                    Console.WriteLine($"\t\t{discipline.Name} with {discipline.NumExercises} exercises and {discipline.NumLectures} lectures");
                }
            }
            Console.WriteLine("The students in the class are:");
            foreach (var student in myClass.Students)
            {
                Console.WriteLine($"\t{student.Name} with unique ID: {student.ClassNum}");
            }

            studentOne.AddComment("STUDENT ONE COMMENT");
            Console.WriteLine($"Student comment: {string.Join(", ", studentOne.MyComments)}");
            myClass.AddComment("CLASS COMMENT");
            Console.WriteLine($"Student comment: {string.Join(", ", myClass.MyComments)}");
            teacherOne.AddComment("TEACHER ONE COMMENT");
            Console.WriteLine($"Student comment: {string.Join(", ", teacherOne.MyComments)}");
            disciplineOne.AddComment("DISCIPLINE ONE COMMENT");
            Console.WriteLine($"Student comment: {string.Join(", ", disciplineOne.MyComments)}");

        }
    }
}
