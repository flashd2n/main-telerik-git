using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateProjectCommand : Command, ICommand
    {
        public CreateProjectCommand(IDatabase database, IModelsFactory factory) : base(database, factory)
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

            if (this.Database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var projectName = parameters[0];
            var projectStartingDate = parameters[1];
            var projectEndingDate = parameters[2];
            var projectState = parameters[3];

            var project = this.ModelsFactory.CreateProject(projectName, projectStartingDate, projectEndingDate, projectState);

            this.Database.Projects.Add(project);

            var successMessage = "Successfully created a new project!";

            return successMessage;
        }
    }
}
