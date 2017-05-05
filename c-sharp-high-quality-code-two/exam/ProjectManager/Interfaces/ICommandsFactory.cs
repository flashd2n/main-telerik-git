using ProjectManager.Commands;

namespace ProjectManager.Interfaces
{
    /// <summary>
    /// Interface for the CommandsFactory class
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Reads a command as a string and returns the correct command instance
        /// </summary>
        /// <param name="commandName">Command name as string</param>
        /// <returns></returns>
        ICommand CreateCommandFromString(string commandName);
    }
}
