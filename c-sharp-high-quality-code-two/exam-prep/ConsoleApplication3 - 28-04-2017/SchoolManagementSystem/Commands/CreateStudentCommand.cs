using System.Collections.Generic;

namespace SchoolManagementSystem.Commands
{
    internal class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> commandParameters)
        {
            var firstName = commandParameters[0];
            var lastName = commandParameters[1];
            var grade = (Grade)int.Parse(commandParameters[2]);
            
            Engine.Students.Add(id, new Student(firstName, lastName, grade));

            var successMessage = $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";

            ++id;
            return successMessage;
        }
    }
}
