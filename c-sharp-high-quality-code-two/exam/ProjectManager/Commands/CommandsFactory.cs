using ProjectManager.Data;
using ProjectManager.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace ProjectManager.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private IDatabase database;
        private IModelsFactory modelsFactory;

        public CommandsFactory(IDatabase database, IModelsFactory modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var command = this.BuildCommand(commandName);

            var outputCommand = this.ParseCommand(command);

            return outputCommand;
        }

        private string BuildCommand(string parameters)
        {
            var command = parameters.ToLower();

            return command;
        }

        private ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
            var command = Activator.CreateInstance(commandTypeInfo, this.database, this.modelsFactory) as ICommand;

            return command;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}