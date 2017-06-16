using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class ValidatableCommand : ICommand
    {
        private readonly ICommand command;

        public ValidatableCommand(ICommand command)
        {
            this.command = command;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != this.ParameterCount)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return this.command.Execute(parameters);
        }
    }
}
