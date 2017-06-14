using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private readonly IModelsFactory modelsFactory;
        private readonly IIdProvider idProvider;
        private readonly IDatabase database;

        public CreateTeacherCommand(IModelsFactory modelsFactory, IIdProvider idProvider, IDatabase database)
        {
            this.modelsFactory = modelsFactory;
            this.idProvider = idProvider;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.modelsFactory.CreateTeacher(firstName, lastName, subject);

            var teacherId = this.idProvider.GetNextTeacherID();

            this.database.Teachers.Add(teacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {teacherId} was created.";
        }
    }
}
