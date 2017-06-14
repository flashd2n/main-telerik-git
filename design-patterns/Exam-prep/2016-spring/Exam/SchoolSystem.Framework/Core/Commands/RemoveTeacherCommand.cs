using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private readonly IDatabase database;

        public RemoveTeacherCommand(IDatabase database)
        {
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            if (!this.database.Teachers.ContainsKey(teacherId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.database.Teachers.Remove(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
