using System.Linq;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Commands.Contracts;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class CommandProcessor : IProcessor
    {
        private readonly ICommandsFactory commandFactory;

        public CommandProcessor(ICommandsFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public string ProcessCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new UserValidationException("No command has been provided!");
            }

            var commandName = commandLine.Split(' ')[0];
            var commandParameters = commandLine
                .Split(' ')
                .Skip(1)
                .ToList();

            var command = this.commandFactory.GetCommandFromString(commandName);

            return command.Execute(commandParameters);
        }
    }
}
