using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Enumerations;
using ProjectManager.Interfaces;
using System;

namespace ProjectManager.Models
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly Validator validator = new Validator();

        public Project CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;

            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);

            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            var projectState = default(ProjectState);

            switch (state)
            {
                case "Active":
                    projectState = ProjectState.Active;
                    break;
                case "Inactive":
                    projectState = ProjectState.Inactive;
                    break;
                default:
                    throw new ArgumentException("The passed project state is not recognized");
            }

            var project = new Project(name, starting, end, projectState);

            this.validator.Validate(project);

            return project;
        }

        public ITask CreateTask(IUser owner, string name, string state)
        {
            var taskState = default(TaskState);

            switch (state)
            {
                case "Pending":
                    taskState = TaskState.Pending;
                    break;
                case "InProgress":
                    taskState = TaskState.InProgress;
                    break;
                case "Done":
                    taskState = TaskState.Done;
                    break;
                default:
                    throw new ArgumentException("The passed task state is not recognized");
            }

            var task = new Task(name, owner, taskState);

            this.validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            var user = new User(username, email);

            this.validator.Validate(user);

            return user;
        }
    }
}
