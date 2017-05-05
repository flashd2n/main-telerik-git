using ProjectManager.Interfaces;
using System.Linq;

namespace ProjectManager.Common
{
    public class CommandProcessor : ICommandProcessor
    {
        private ICommandsFactory commandsFactory;
        
        public CommandProcessor(ICommandsFactory commandsFactory)
        {
            this.commandsFactory = commandsFactory;
        }

        public string ProcessCommand(string rawCommand)
        {
            if (string.IsNullOrWhiteSpace(rawCommand))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var commandName = rawCommand.Split(' ')[0];

            var command = this.commandsFactory.CreateCommandFromString(commandName);

            var commandParameters = rawCommand.Split(' ').Skip(1).ToList();

            return command.Execute(commandParameters);
        }
    }
}
