using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using System.Text;
using System.Linq;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private readonly IDatabase database;

        public StudentListMarksCommand(IDatabase database)
        {
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.database.Students[studentId];

            var studentMarks = student.Marks;

            if (studentMarks.Count == 0)
            {
                return "This student has no marks.";
            }

            var builder = new StringBuilder();
            builder.AppendLine("The student has these marks:");

            var marksAsString = studentMarks
                .Select(m => $"{m.Subject} => {m.Value}")
                .ToList();

            marksAsString.ForEach(m => builder.AppendLine(m));

            var result = builder.ToString();

            return result;
        }
    }
}
