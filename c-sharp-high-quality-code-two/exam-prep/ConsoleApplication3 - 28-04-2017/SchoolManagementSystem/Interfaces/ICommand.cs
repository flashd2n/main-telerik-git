using System.Collections.Generic;

namespace SchoolManagementSystem
{
    /// <summary>
    /// Describes a valid command for the program
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Runs the command
        /// </summary>
        /// <param name="parameters">Command parameters</param>
        /// <returns></returns>
        string Execute(IList<string> parameters);
    }
}
