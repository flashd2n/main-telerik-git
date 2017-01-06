// 03.Write a method that from a given array of students finds all students whose first name is before its last name 
//alphabetically. Use LINQ query operators.

// 04.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

// 05.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name 
//and last name in descending order. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Startup
    {
        // Find all students whose first name is before its last name alphabetically, using LINQ query
        static void FirstNameBeforeLastName(Students[] array)
        {
            var students =
                from stud in array
                where stud.FirstName.CompareTo(stud.LastName) == -1
                select stud;

            Console.WriteLine("Students whose first name is before its last name alphabetically: ");

            foreach (var element in students)
            {
                Console.WriteLine("{0} {1}", element.FirstName, element.LastName);
            }

            Console.WriteLine("--------------------");
        }

        // Find the first name and last name of all students with age between 18 and 24
        static void StudentsWithGivenAge(Students[] array)
        {
            var students =
                from stud in array
                where (stud.Age >= 18 && stud.Age <= 24)
                select stud;

            Console.WriteLine("Students with age between 18 and 24: ");

            foreach (var element in students)
            {
                Console.WriteLine("{0} {1} {2}", element.FirstName, element.LastName, element.Age);
            }

            Console.WriteLine("--------------------");
        }

        // Sort the students by first name and last name in descending order, using lambda expressions
        static void SortStudentsUsingLambda(Students[] array)
        {
            var students = array.OrderByDescending(x => x.FirstName).ThenByDescending(y => y.LastName);

            Console.WriteLine("Sort students, using lambda expressions: ");

            foreach (var element in students)
            {
                Console.WriteLine("{0} {1}", element.FirstName, element.LastName);
            }

            Console.WriteLine("--------------------");
        }

        // Sort the students by first name and last name in descending order, using LINQ query
        static void SortStudentsUsingLINQ(Students[] array)
        {
            var students =
                from stud in array
                orderby stud.FirstName descending, stud.LastName descending
                select stud;

            Console.WriteLine("Sort students, using LINQ query: ");

            foreach (var element in students)
            {
                Console.WriteLine("{0} {1}", element.FirstName, element.LastName);
            }

            Console.WriteLine("--------------------");
        }

        static void Main(string[] args)
        {
            Students[] arrayOfStudents =
            {
                new Students("Plamen", "Georgiev", 22),
                new Students("Ivan", "Ivanov", 12),
                new Students("Mitko", "Asenov", 31),
                new Students("Angel", "Dimitrov", 24),
                new Students("Mitko", "Marinov", 18)
            };

            FirstNameBeforeLastName(arrayOfStudents);
            StudentsWithGivenAge(arrayOfStudents);
            SortStudentsUsingLambda(arrayOfStudents);
            SortStudentsUsingLINQ(arrayOfStudents);
        }
    }
}