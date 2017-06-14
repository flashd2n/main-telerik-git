using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IModelsFactory modelsFactory;
        private readonly IIdProvider idProvider;
        private readonly IDatabase database;

        public CreateStudentCommand(IModelsFactory modelsFactory, IIdProvider idProvider, IDatabase database)
        {
            this.modelsFactory = modelsFactory;
            this.idProvider = idProvider;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.modelsFactory.CreateStudent(firstName, lastName, grade);

            var studentId = this.idProvider.GetNextStudentId();

            this.database.Students.Add(studentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {studentId} was created.";
        }
    }
}
