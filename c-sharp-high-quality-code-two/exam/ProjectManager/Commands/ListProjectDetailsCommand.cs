using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class ListProjectDetailsCommand : Command, ICommand
    {
        public ListProjectDetailsCommand(IDatabase database, IModelsFactory factory) : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 1)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projectId = int.Parse(parameters[0]);

            if (projectId >= this.Database.Projects.Count || projectId < 0)
            {
                throw new ArgumentException("There is no project with this id");
            }

            var project = this.Database.Projects[projectId];

            var result = project.ToString();

            return result;
        }
    }
}
