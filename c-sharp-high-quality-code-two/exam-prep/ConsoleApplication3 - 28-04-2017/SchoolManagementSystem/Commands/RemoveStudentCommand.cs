using System.Collections.Generic;

namespace SchoolManagementSystem.Commands
{
    internal class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            var studentID = int.Parse(commandParameters[0]);

            Engine.Students.Remove(studentID);

            var successMessage = $"Student with ID {studentID} was sucessfully removed.";

            return successMessage;
        }
    }
}
