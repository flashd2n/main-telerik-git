using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Data
{
    /// <summary>
    /// Interface for Database
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Contains all projects
        /// </summary>
        IList<IProject> Projects { get; }
    }
}
