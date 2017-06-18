using System.Collections.Generic;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Models;
using System.Linq;

namespace ProjectManager.Data
{
    public class InMemoryDatabase : IDatabase
    {
        private IList<Project> projects;

        public InMemoryDatabase()
        {
            this.projects = new List<Project>();
        }

        public bool IsProjectExist(string name)
        {
            return this.projects.Any(x => x.Name == name);
        }

        public void AddProject(Project project)
        {
            this.projects.Add(project);
        }

        public Project FindProjectById(int id)
        {
            return this.projects[id];
        }

        public int GetProjectsCount()
        {
            return this.projects.Count();
        }

        public IList<Project> GetAllProjects()
        {
            return this.projects;
        }
    }
}
