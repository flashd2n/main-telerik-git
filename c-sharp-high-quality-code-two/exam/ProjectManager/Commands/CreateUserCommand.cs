using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : Command, ICommand
    {
        public CreateUserCommand(IDatabase database, IModelsFactory factory) : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projectId = int.Parse(parameters[0]);
            var username = parameters[1];

            var databaseHasUsers = this.Database.Projects[projectId].Users.Any();

            var databaseHasCurrentUser = this.Database.Projects[projectId].Users.Any(x => x.Name == username);

            if (databaseHasUsers && databaseHasCurrentUser)
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var userEmail = parameters[2];

            var user = this.ModelsFactory.CreateUser(username, userEmail);

            this.Database.Projects[projectId].Users.Add(user);

            var successMessage = "Successfully created a new user!";

            return successMessage;
        }
    }
}
