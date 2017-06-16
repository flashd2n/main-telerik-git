using System;
using System.Collections.Generic;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public class ListProjectsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 0;

        public ListProjectsCommand(IDatabase database) : base(database)
        {
        }

        public override int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }

        public override string Execute(IList<string> parameters)
        {
            var projects = this.database.GetAllProjects();

            if(this.database.GetProjectsCount() == 0)
            {
                return "No projects in the database!";
            }

            return string.Join(Environment.NewLine, projects);
        }
    }
}
