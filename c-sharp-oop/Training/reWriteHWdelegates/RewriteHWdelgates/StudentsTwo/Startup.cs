using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTwo
{
    class Startup
    {
        static void Main()
        {

            List<Student> allStudents = new List<Student>()
            {
                new Student("Plamen", "Georgiev", 103189, "0286332", "plamen@abv.bg", new List<int> {6, 3, 4, 2, 3}, new Group(2, "Computing")),
                new Student("Ivan", "Ivanov", 115106, "5551223", "ivan@gmail.com", new List<int> {3, 2, 2, 6, 3}, new Group(2, "Physics")),
                new Student("Gosho", "Goshov", 106106, "0044213", "gosho@mail.com", new List<int> {5, 2 ,2, 4, 4}, new Group(13, "Mathematics")),
                new Student("Mitko", "Mitkov", 222213, "0223267", "mitko@gmail.com", new List<int> {6, 6, 6, 2, 2}, new Group(14, "Physics")),
                new Student("Marina", "Marinova", 333606, "088088333", "marina@abv.bg", new List<int> {2, 2, 2, 6, 6}, new Group(9, "Biology")),
                new Student("Krum", "Krumov", 122289, "0686636", "krum@abv.bg", new List<int> {2, 3, 3, 2, 3}, new Group(13, "Biology")),
                new Student("Petko", "Petkov", 111106, "0101223", "petko@gmail.com", new List<int> {6, 6, 6, 6, 6}, new Group(1, "Physics")),
                new Student("Iva", "Ivova", 206206, "0555222", "iva@mail.com", new List<int> {5, 5, 5, 5, 5}, new Group(6, "Physics")),
                new Student("Dimo", "Dimov", 189189, "03338834", "dimo@gmail.com", new List<int> {3, 6, 6, 3, 2}, new Group(16, "Physics")),
                new Student("Krasen", "Petkov", 322300, "088088222", "krasen@abv.bg", new List<int> {2, 3, 2, 6, 3}, new Group(2, "Mathematics"))
            };

            var groupTwo = from student in allStudents
                           where student.Group.GroupNumber == 2
                           select student;

            Console.WriteLine("Students in Group 2");
            foreach (var student in groupTwo)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var orderStudentsFirstName = from student in allStudents
                                         orderby student.FirstName
                                         select student;

            Console.WriteLine("Students Ordered By First Name");
            foreach (var student in orderStudentsFirstName)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            Console.WriteLine("Students in Group Extension Method");
            var groupTwoExt = allStudents.GetByGroup(2);
            foreach (var student in groupTwoExt)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            Console.WriteLine("Students Ordered By First Name Extension Method");
            var orderStudentsFirstNameExt = allStudents.OrderByFirstName();
            foreach (var student in orderStudentsFirstNameExt)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var studentsAbvBg = from student in allStudents
                                where student.Email.IndexOf("abv.bg") != -1
                                select student;

            Console.WriteLine("Students with abv.bg Email");
            foreach (var student in studentsAbvBg)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var studentsPhoneSofia = from student in allStudents
                                     where student.Tel.Substring(0, 2) == "02"
                                     select student;

            Console.WriteLine("Students with Sofia Phone Number");
            foreach (var student in studentsPhoneSofia)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var studentsExcellent = from student in allStudents
                                    where student.Marks.Contains(6)
                                    select new { FullName = $"{student.FirstName} {student.LastName}", Marks = student.Marks };

            Console.WriteLine("Students with excellent marks");
            foreach (var student in studentsExcellent)
            {
                Console.WriteLine($"\t{student.FullName} has the following marks: {string.Join(", ", student.Marks)}");
            }

            var studentsWithTwos = allStudents.GetStudentsMarkTwo();

            Console.WriteLine("Students with exactly two 2's");
            foreach (var student in studentsWithTwos)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var studentsFrom06 = from student in allStudents
                                 where student.FN.ToString().Substring(student.FN.ToString().Length - 2, 2) == "06"
                                 select student;

            Console.WriteLine("Students from 2006");
            foreach (var student in studentsFrom06)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} has the following marks: {string.Join(", ", student.Marks)}");
            }


            var mathStudents = from student in allStudents
                               where student.Group.DeptName == "Mathematics"
                               select student;

            Console.WriteLine("MathStudents");
            foreach (var student in mathStudents)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var groupedByGroupNum = from student in allStudents
                                    group student by student.Group.GroupNumber;

            Console.WriteLine("Grouped by Group Number");
            foreach (var student in groupedByGroupNum)
            {
                Console.WriteLine($"\tGroup {student.Key} has {student.Count()} students in it:");
                foreach (var item in student)
                {
                    Console.WriteLine($"\t\t{item.FirstName} {item.LastName}");
                }
            }

            var groupedByGroupNumExt = allStudents.GroupByGroupNumExt();

            Console.WriteLine("Grouped by Group Number EXTENSION");
            foreach (var student in groupedByGroupNumExt)
            {
                Console.WriteLine($"\tGroup {student.Key} has {student.Count()} students in it:");
                foreach (var item in student)
                {
                    Console.WriteLine($"\t\t{item.FirstName} {item.LastName}");
                }
            }
        }
    }
}
