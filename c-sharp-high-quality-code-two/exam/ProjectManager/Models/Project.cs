using ProjectManager.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class Project : IProject
    {
        private string name;

        public Project(string projectName, DateTime projectStartingDate, DateTime projectEndingDate, ProjectState projectState)
        {
            this.Name = projectName;
            this.StartingDate = projectStartingDate;
            this.EndingDate = projectEndingDate;
            this.State = projectState;
            this.Users = new List<IUser>();
            this.Tasks = new List<ITask>();
        }

        [Required(ErrorMessage = "Project Name is required!")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The project name cannot be null empty or contain only whitespace");
                }

                this.name = value;
            }
        }

        [Range(typeof(DateTime), "1800-1-1", "2017-1-1", ErrorMessage = "Project StartingDate must be between 1800-1-1 and 2017-1-1!")]
        public DateTime StartingDate { get; set; }

        [Range(typeof(DateTime), "2018-1-1", "2144-1-1", ErrorMessage = "Project EndingDate must be between 2018-1-1 and 2144-1-1!")]
        public DateTime EndingDate { get; set; }

        public ProjectState State { get; set; }

        public virtual IList<IUser> Users { get; set; }

        public virtual IList<ITask> Tasks { get; set; }

        public override string ToString()
        {
            var projectInformation = new StringBuilder();

            projectInformation.AppendLine("Name: " + this.Name);
            projectInformation.AppendLine("  Starting date: " + this.StartingDate.ToString("yyyy-MM-dd"));
            projectInformation.AppendLine("  Ending date: " + this.EndingDate.ToString("yyyy-MM-dd"));
            projectInformation.AppendLine("  State: " + this.State);
            projectInformation.AppendLine("  Users: ");

            var curentUsers = string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Users);

            projectInformation.Append(curentUsers);

            if (this.Users.Count == 0)
            {
                projectInformation.AppendLine("  - This project has no users!");
            }

            projectInformation.AppendLine("  Tasks: ");

            var currentTasks = string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Tasks);

            projectInformation.Append(currentTasks);

            if (this.Tasks.Count == 0)
            {
                projectInformation.Append("  - This project has no tasks!");
            }

            var result = projectInformation.ToString();

            return result;
        }
    }
}