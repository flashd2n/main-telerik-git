using System.Collections.Generic;

namespace SchoolManagementSystem.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            var teacherID = int.Parse(commandParameters[0]);

            Engine.Teachers.Remove(teacherID);

            var successMessage = $"Teacher with ID {teacherID} was sucessfully removed.";

            return successMessage;
        }
    }
}
