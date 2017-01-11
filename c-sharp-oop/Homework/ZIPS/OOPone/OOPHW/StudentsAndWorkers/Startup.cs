using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    class Startup
    {
        static void Main()
        {
            // Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method
            List<Student> allStudents = new List<Student>()
            {
                new Student("Alexander", "Dimitrov", 5.7),
                new Student("Mario", "Ivanov", 4.7),
                new Student("Atanaska", "Kovacheva", 3.2),
                new Student("Yana", "Hristova", 5.1),
                new Student("Kalin", "Kostov", 5.8),
                new Student("Krasimir", "Draganov", 3.9),
                new Student("Veronika", "Ficherova", 2.7),
                new Student("Todor", "Todorov", 5.2),
                new Student("Pencho", "Penchev", 4.3),
                new Student("Petya", "Dimitrova", 3.3)
            };

            var sortedByGrade = from student in allStudents
                                orderby student.Grade
                                select student;

            Console.WriteLine("Sorted Students By Grade Using LINQ");
            foreach (var student in sortedByGrade)
            {
                Console.WriteLine($"\tName: {student.FirstName} {student.LastName}; Grade: {student.Grade}");
            }

            Console.WriteLine("\nSorted Students By Grade Using Extension Method");
            var sortedByGradeEXT = allStudents.OrderBy(x => x.Grade);
            foreach (var student in sortedByGradeEXT)
            {
                Console.WriteLine($"\tName: {student.FirstName} {student.LastName}; Grade: {student.Grade}");
            }

            // Initialize a list of 10 workers and sort them by money per hour in descending order.

            List<Worker> allWorkers = new List<Worker>()
            {
                new Worker("Alexander", "Ivanov", 600, 12),
                new Worker("Krasena", "Krumova", 480, 8),
                new Worker("Karina", "Mineva", 170, 8),
                new Worker("Haralampi", "Takov", 190, 8),
                new Worker("Vasil", "Beluhov", 450, 12),
                new Worker("Ivailo", "Milanov", 310, 8),
                new Worker("Stefan", "Varbanov", 325, 12),
                new Worker("Kaloyan", "Yanchev", 400, 8),
                new Worker("Tomislav", "Todorov", 125, 12),
                new Worker("Emilly", "Gerasimova", 550, 8),
            };

            var sortedByMoneyPerHour = from worker in allWorkers
                                       orderby worker.MoneyPerHour() descending
                                       select worker;

            Console.WriteLine("\nSorted Workers By Money Per Hour");
            foreach (var worker in sortedByMoneyPerHour)
            {
                Console.WriteLine($"\tName: {worker.FirstName} {worker.LastName} earns {worker.MoneyPerHour():C2} per hour");
            }

            // Merge the lists and sort them by first name and last name.

            List<Human> mergedStudentsWorkers = new List<Human>();
            mergedStudentsWorkers.AddRange(allStudents);
            mergedStudentsWorkers.AddRange(allWorkers);

            var sortedStudentsWorkers = from person in mergedStudentsWorkers
                                        orderby person.FirstName, person.LastName
                                        select person;

            Console.WriteLine("\nMerged And Sorted Lists");
            foreach (var person in sortedStudentsWorkers)
            {
                Console.WriteLine($"\tName: {person.FirstName} {person.LastName}");
            }

        }
    }
}
