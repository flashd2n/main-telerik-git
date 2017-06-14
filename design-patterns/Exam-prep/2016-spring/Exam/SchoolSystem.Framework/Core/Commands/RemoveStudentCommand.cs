using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private readonly IDatabase database;

        public RemoveStudentCommand(IDatabase database)
        {
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            this.database.Students.Remove(studentId);

            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
