using System.Collections.Generic;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateTaskCommand : CreationalCommand, ICommand
    {
        private const int ParameterCountConstant = 4;

        public CreateTaskCommand(IModelsFactory factory, IDatabase database) 
            : base(factory, database)
        {
        }

        public override int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }
        
        public override string Execute(IList<string> parameters)
        {
            var projectId = int.Parse(parameters[0]);
            var project = this.database.FindProjectById(projectId);

            var ownerId = int.Parse(parameters[1]);
            var owner = project.Users[ownerId];

            var task = this.factory.GetTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
