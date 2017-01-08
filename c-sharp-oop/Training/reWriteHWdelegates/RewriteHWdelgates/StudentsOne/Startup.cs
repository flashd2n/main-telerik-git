using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsOne
{
    class Startup
    {
        static void Main()
        {
            var allStudents = new List<Students>()
            {
                new Students("Gosho", "Goshev", 16),
                new Students("Tosho", "Toshev", 18),
                new Students("Tosho", "Toshav", 18),
                new Students("Kalin", "Kostov", 20),
                new Students("Alexander", "Dimitrov", 22),
                new Students("Mario", "Ivanov", 24),
                new Students("Yana", "Hristova", 26),
            };

            var firstBeforeLast = from student in allStudents
                                  where student.FirstName.CompareTo(student.LastName) < 0
                                  select student;

            Console.WriteLine("First Before Last");
            foreach (var student in firstBeforeLast)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var ageRange = from student in allStudents
                           where student.Age >= 18 && student.Age <= 24                           
                           select student;

            Console.WriteLine("Age Range");
            foreach (var student in ageRange)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var reOrdered = allStudents.OrderByDescending(student => { return student.FirstName; }).ThenByDescending(student => { return student.LastName; });

            Console.WriteLine("Order Students -> Lambda");
            foreach (var student in reOrdered)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }

            var reOrderedLINQ = from student in allStudents
                            orderby student.FirstName descending, student.LastName descending
                            select student;

            Console.WriteLine("Order Students -> LINQ");
            foreach (var student in reOrderedLINQ)
            {
                Console.WriteLine($"\t{student.FirstName}, {student.LastName}");
            }
        }
    }
}
