using System.Collections.Generic;

namespace SchoolManagementSystem.Commands
{
    internal class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            var teacherId = int.Parse(commandParameters[0]);
            var studentid = int.Parse(commandParameters[1]);
            var markValue = float.Parse(commandParameters[2]);
            
            var teacher = Engine.Teachers[teacherId];
            var student = Engine.Students[studentid];

            var markToAdd = new Mark(teacher.Subject, markValue);

            teacher.AddMark(student, markToAdd);

            var successMessage = $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";

            return successMessage;
        }
    }
}
