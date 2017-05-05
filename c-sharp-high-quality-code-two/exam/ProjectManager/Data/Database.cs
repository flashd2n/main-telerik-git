using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Data
{
    public class Database : IDatabase
    {
        private static IList<IProject> projects;

        static Database()
        {
            projects = new List<IProject>();
        }

        public IList<IProject> Projects
        {
            get
            {
                return projects;
            }
        }
    }
}
