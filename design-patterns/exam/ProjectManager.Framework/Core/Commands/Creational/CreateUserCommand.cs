using System.Collections.Generic;
using System.Linq;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateUserCommand : CreationalCommand, ICommand
    {
        private const int ParameterCountConstant = 3;

        public CreateUserCommand(IModelsFactory factory, IDatabase database) 
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

            if (project.Users.Any() && project.Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = this.factory.GetUser(parameters[1], parameters[2]);
            project.Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}
