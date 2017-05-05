using ProjectManager.Models;

namespace ProjectManager.Interfaces
{
    /// <summary>
    /// Interface for models factory
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Returns a new instance of the project class
        /// </summary>
        /// <param name="name">Project Name</param>
        /// <param name="startingDate">Starting date for the project</param>
        /// <param name="endingDate">Ending date for the project</param>
        /// <param name="state">State of the project</param>
        /// <returns></returns>
        Project CreateProject(string name, string startingDate, string endingDate, string state);

        /// <summary>
        /// Returns a new instance of the task class
        /// </summary>
        /// <param name="owner">Owner of the task</param>
        /// <param name="name">Name of the task</param>
        /// <param name="state">State of the task</param>
        /// <returns></returns>
        ITask CreateTask(IUser owner, string name, string state);

        /// <summary>
        /// Returns a new instance of the user class
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="email">Email of the user</param>
        /// <returns></returns>
        IUser CreateUser(string username, string email);
    }
}
