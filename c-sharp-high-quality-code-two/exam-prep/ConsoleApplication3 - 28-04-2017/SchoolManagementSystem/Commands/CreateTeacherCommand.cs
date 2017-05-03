using System.Collections.Generic;

namespace SchoolManagementSystem.Commands
{
    internal class CreateTeacherCommand : ICommand
    {
        private int id = 0;

        public string Execute(IList<string> commandParameters)
        {
            var firstName = commandParameters[0];
            var lastName = commandParameters[1];
            var subject = (Subject)int.Parse(commandParameters[2]);

            Engine.Teachers.Add(this.id, new Teacher(firstName, lastName, subject));
            
            var successMessage = $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";

            this.id++;

            return successMessage;
        }
    }
}
