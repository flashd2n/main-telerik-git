using System.Collections.Generic;

using ProjectManager.Framework.Data.Models;

namespace ProjectManager.Framework.Data
{
    public interface IDatabase
    {
        bool IsProjectExist(string name);
        void AddProject(Project project);
        Project FindProjectById(int id);
        int GetProjectsCount();
        IList<Project> GetAllProjects();
    }
}
