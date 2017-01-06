using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTaskThree
{
    class Startup
    {
        // Print students
        static void Print(IEnumerable<IEnumerable<Student>> array)
        {
            foreach (var group in array)
            {
                foreach (var element in group)
                {
                    Console.WriteLine("Full name: {0} {1} \nGroup name: {2}", element.FirstName, element.LastName, element.GroupName);
                }

                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------");
        }

        // Extract all students grouped by GroupName, using LINQ
        static void GroupStudentByGroupNameUsingLINQ(List<Student> array)
        {
            var students =
               from stud in array
               group stud by stud.GroupName into newGroup
               orderby newGroup.Key
               select newGroup;

            Console.WriteLine("Print students grouped by GroupName: (Using LINQ query) ");
            Print(students);
        }

        // Extract all students grouped by GroupName, using extension methods
        static void GroupStudentByGroupNameUsingLambda(List<Student> array)
        {
            var students = array.GroupBy(x => x.GroupName).OrderBy(y => y.Key);

            Console.WriteLine("Print students grouped by GroupName: (Using Lambda expression) ");
            Print(students);
        }

        static void Main(string[] args)
        {
            List<Student> list = new List<Student>()
            {
                new Student("Plamen", "Georgiev", "Telerik"),
                new Student("Ivan", "Ivanov", "MusalaSoft"),
                new Student("Teodor", "Dimitrov", "TechNews"),
                new Student("Dimitrina", "Todorova", "Telerik"),
                new Student("Maria", "Ficheva", "Kaldata"),
                new Student("Grigor", "Dimitrov", "MusalaSoft"),
                new Student("Petar", "Petrov", "MusalaSoft"),
                new Student("Svetlin", "Nakov", "Telerik"),
                new Student("Nikolay", "Kostov", "Telerik"),
                new Student("Krasen", "Petrov", "TechNews")
            };

            GroupStudentByGroupNameUsingLINQ(list);
            GroupStudentByGroupNameUsingLambda(list);
        }
    }
}