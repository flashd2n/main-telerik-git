using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateTaskCommand : Command, ICommand
    {
        public CreateTaskCommand(IDatabase database, IModelsFactory factory) : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projectId = int.Parse(parameters[0]);
            var project = this.Database.Projects[projectId];

            var ownerId = int.Parse(parameters[1]);
            var owner = project.Users[ownerId];

            var taskName = parameters[2];
            var taskState = parameters[3];

            var task = this.ModelsFactory.CreateTask(owner, taskName, taskState);

            project.Tasks.Add(task);

            var successMessage = "Successfully created a new task!";

            return successMessage;
        }
    }
}
