using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask
{
    class StudentTest
    {
        private static Student studentOne;
        private static Student studentTwo;
        private static Student studentThree;

        static void Main()
        {
            var pencho = new Student("pencho penchev", "some course", "some subject");
            pencho.PrintInfo();
            Console.WriteLine("=======");
            CreateStudents();
            PrintInfo(StudentOne);
            PrintInfo(StudentTwo);
            PrintInfo(StudentThree);
        }

        static void CreateStudents()
        {
            StudentOne = new Student("pencho penchev", "some course", "some subject");
            StudentTwo = new Student("gosho goshev", "some course", "some subject");
            StudentThree = new Student("tosho toshev", "some course", "some subject");
        }

        public static void PrintInfo(Student student)
        {
            Console.WriteLine($"Name: {student.FullName}\nCourse: {student.Course}\nSubject: {student.Subject}\nUniversity: {student.University}\nEmail: {student.Email}\nPhoneNumber: {student.PhoneNumber}");
        }

        static Student StudentOne
        {
            get
            {
                return studentOne;
            }
            set
            {
                studentOne = value;
            }
        }
        static Student StudentTwo
        {
            get
            {
                return studentTwo;
            }
            set
            {
                studentTwo = value;
            }
        }
        static Student StudentThree
        {
            get
            {
                return studentThree;
            }
            set
            {
                studentThree = value;
            }
        }
    }
}
