using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class ListProjectsCommand : Command, ICommand
    {
        public ListProjectsCommand(IDatabase database, IModelsFactory factory) : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var result = string.Join(Environment.NewLine, this.Database.Projects);

            return result;
        }
    }
}
