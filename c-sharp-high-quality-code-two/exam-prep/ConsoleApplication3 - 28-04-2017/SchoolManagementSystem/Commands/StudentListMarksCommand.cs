using System.Collections.Generic;

namespace SchoolManagementSystem.Commands
{
    internal class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            var studentId = int.Parse(commandParameters[0]);

            var student = Engine.Students[studentId];

            var studentMarks = student.ListMarks();

            return studentMarks;
        }
    }
}
