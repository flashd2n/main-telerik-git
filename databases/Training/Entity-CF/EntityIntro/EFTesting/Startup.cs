using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFTesting
{
    public class Startup
    {
        static void Main()
        {
            var dbContext = new TelerikAcademyEntities();

            var list = new List<Project>()
                    .FirstOrDefault(pr => pr.ProjectID == 1); // FUNC

            var project = dbContext.Projects    
                    .FirstOrDefault(pr => pr.ProjectID == 1); // EXPRESSION

            // custom expression

            Expression<Func<Project, bool>> expr = pr => pr.ProjectID == 1;

            // re-writen

            var list2 = new List<Project>()
                    .FirstOrDefault(CustomFunc); // FUNC

            var project2 = dbContext.Projects
                    .FirstOrDefault(expr); // EXPRESSION

            var employeesByDeparments = dbContext.Employees
                .GroupBy(e => e.Department.Name)
                .ToList();

            foreach (var emplGroup in employeesByDeparments)
            {
                Console.WriteLine(emplGroup.Key);
                foreach (var empl in emplGroup)
                {
                    Console.WriteLine(empl.FirstName + " " + empl.LastName);
                }
                Console.WriteLine("--------");
            }

        }

        // custom func
        private static bool CustomFunc(Project project)
        {
            return project.ProjectID == 1;
        }

    }
}
