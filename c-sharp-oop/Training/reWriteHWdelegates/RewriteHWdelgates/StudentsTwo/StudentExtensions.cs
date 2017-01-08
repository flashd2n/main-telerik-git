using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTwo
{
    public static class StudentExtensions
    {
        public static List<Student> GetByGroup(this List<Student> allStudents, int groupNumber)
        {
            var result = new List<Student>();

            for (int i = 0; i < allStudents.Count; i++)
            {
                if (allStudents[i].Group.GroupNumber == groupNumber)
                {
                    result.Add(allStudents[i]);
                }
            }

            return result;
        }

        public static List<Student> OrderByFirstName(this List<Student> allStudents)
        {
            var result = new List<Student>();

            result = allStudents.OrderBy(student => student.FirstName).ToList();

            return result;
        }

        public static List<Student> GetStudentsMarkTwo(this List<Student> allStudents)
        {
            var result = new List<Student>();
            var mark = 2;
            var occurences = 2;

            result = allStudents.Where(x => x.Marks.Count(y => y == mark) == occurences).ToList();

            return result;
        }

        public static IEnumerable<IGrouping<int, Student>> GroupByGroupNumExt(this List<Student> allStudents)
        {
            var result = allStudents.GroupBy(x => x.Group.GroupNumber);
            return result;
        }

    }
}
