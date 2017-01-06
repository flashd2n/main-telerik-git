using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTaskTwo
{ 
    class Startup
    {
        // Print students
        static void Print(IEnumerable<Student> students)
        {
            foreach (var element in students)
            {
                Console.Write("Name: {0} {1} \nFN: {2} \nTelephone: {3} \nMail: {4} \nGroup: {5} \nMarks: ", element.FirstName, element.LastName, element.FN, element.Telephone, element.Email, element.GroupNumber.GroupNumber);

                // Print marks of current student
                foreach (var item in element.Marks)
                {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("--------------------\n");
        }

        // Select students from group number 2, using LINQ query, oreder by first name
        static void SelectStudentsByGroupNumberWithLINQ(List<Student> array)
        {
            var students =
                from stud in array
                where stud.GroupNumber.GroupNumber == 2
                orderby stud.FirstName
                select stud;

            Console.WriteLine("Students from group number 2 are: (Using LINQ query) ");
            Print(students);
        }

        // Select students from group number 2, using labda expression, oreder by first name
        static void SelectStudentsByGroupNumberWithLambda(List<Student> array)
        {
            var students = array.Where(x => (x.GroupNumber.GroupNumber == 2)).OrderBy(x => x.FirstName);

            Console.WriteLine("Students from group number 2 are: (Using Lambda expressions) ");
            Print(students);
        }

        // Extract all students with email in abv.bg, using LINQ
        static void ExtractStudentsByEmail(List<Student> array)
        {
            var students =
                from stud in array
                where stud.Email.EndsWith("abv.bg")
                select stud;

            Console.WriteLine("Students with email abv.bg: ");
            Print(students);
        }

        // Extract all students with phones in Sofia, using LINQ query
        static void ExtractStudentswithPhoneInSofia(List<Student> array)
        {
            var students =
                from stud in array
                where stud.Telephone.StartsWith("02")
                select stud;

            Console.WriteLine("Students with phones in Sofia: ");
            Print(students);
        }

        // Find all students with at least one mark Excellent
        static void ExtractStudentsWithExcellentGrade(List<Student> array)
        {
            int searchedMark = 6;

            var students =
                from stud in array
                where stud.Marks.Contains(searchedMark)
                select new { FullName = stud.FirstName + " " + stud.LastName, Marks = stud.Marks };

            Console.WriteLine("Students with at least one Excellne grade: ");

            foreach (var element in students)
            {
                Console.WriteLine("Full name: {0}", element.FullName);
                Console.Write("Marks: ");

                // Print marks of the current student
                foreach (var item in element.Marks)
                {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("--------------------\n");
        }

        // Find students with exactly two marks Poor
        static void ExtractStudentsWithTwoPoorMarks(List<Student> array)
        {
            int searchedMark = 2;
            int timesFound = 2;

            var students =
                from stud in array
                where stud.Marks.Count(x => x == searchedMark) == timesFound
                select new { FullName = stud.FirstName + " " + stud.LastName, Marks = stud.Marks };

            Console.WriteLine("Students with exactly two grades Poor: ");

            foreach (var element in students)
            {
                Console.WriteLine("Full name: {0}", element.FullName);
                Console.Write("Marks: ");

                // Print marks of the current student
                foreach (var item in element.Marks)
                {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("--------------------\n");
        }

        // Extract all Marks of the students that enrolled in 2006
        static void ExtractStudentsMarks(List<Student> array)
        {
            var students =
                from stud in array
                where stud.FN.EndsWith("06")
                select stud;

            Console.WriteLine("Students marks enrolled in 2006: ");
            Print(students);
        }

        // Extract all students from "Mathematics" department
        static void ExtractStudentsFromMathematicsDepartment(List<Student> array)
        {
            var students =
                from stud in array
                where stud.GroupNumber.DepartmentName == "Mathematics"
                select stud;

            Console.WriteLine("Students from \"Mathematics\" department: ");
            Print(students);
        }

        static void Main(string[] args)
        {
            List<Student> list = new List<Student>()
            {
                new Student("Plamen", "Georgiev", "103189", "0286332", "plamen@abv.bg", new List<int> {6, 3, 4, 2, 3}, new Group(2, "Computing")),
                new Student("Ivan", "Ivanov", "115106", "5551223", "ivan@gmail.com", new List<int> {3, 2, 2, 6, 3}, new Group(2, "Physics")),
                new Student("Gosho", "Goshov", "106106", "0044213", "gosho@mail.com", new List<int> {5, 2 ,2, 4, 4}, new Group(13, "Mathematics")),
                new Student("Mitko", "Mitkov", "222213", "0223267", "mitko@gmail.com", new List<int> {6, 6, 6, 2, 2}, new Group(14, "Physics")),
                new Student("Marina", "Marinova", "333606", "088088333", "marina@abv.bg", new List<int> {2, 2, 2, 6, 6}, new Group(9, "Biology")),
                new Student("Krum", "Krumov", "122289", "0686636", "krum@abv.bg", new List<int> {2, 3, 3, 2, 3}, new Group(13, "Biology")),
                new Student("Petko", "Petkov", "111106", "0101223", "petko@gmail.com", new List<int> {6, 6, 6, 6, 6}, new Group(1, "Physics")),
                new Student("Iva", "Ivova", "206206", "0555222", "iva@mail.com", new List<int> {5, 5, 5, 5, 5}, new Group(6, "Physics")),
                new Student("Dimo", "Dimov", "189189", "03338834", "dimo@gmail.com", new List<int> {3, 6, 6, 3, 2}, new Group(16, "Physics")),
                new Student("Krasen", "Petkov", "322300", "088088222", "krasen@abv.bg", new List<int> {2, 3, 2, 6, 3}, new Group(2, "Mathematics"))
            };

            SelectStudentsByGroupNumberWithLINQ(list);
            SelectStudentsByGroupNumberWithLambda(list);
            ExtractStudentsByEmail(list);
            ExtractStudentswithPhoneInSofia(list);
            ExtractStudentsWithExcellentGrade(list);
            ExtractStudentsWithTwoPoorMarks(list);
            ExtractStudentsMarks(list);
            ExtractStudentsFromMathematicsDepartment(list);
        }
    }
}