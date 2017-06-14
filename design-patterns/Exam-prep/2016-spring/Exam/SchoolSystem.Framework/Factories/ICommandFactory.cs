using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Factories
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
