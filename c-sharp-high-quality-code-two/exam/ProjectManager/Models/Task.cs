using ProjectManager.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class Task : ITask
    {
        public Task(string taskName, IUser taskOwner, TaskState taskState)
        {
            this.Name = taskName;
            this.Owner = taskOwner;
            this.State = taskState;
        }

        [Required(ErrorMessage = "Task Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task Owner is required")]
        public IUser Owner { get; set; }

        public TaskState State { get; set; }

        public override string ToString()
        {
            var taskInformation = new StringBuilder();

            taskInformation.AppendLine("    Name: " + this.Name);
            taskInformation.AppendLine("    Owner: " + this.Owner.Name);
            taskInformation.Append("    State: " + this.State);

            var result = taskInformation.ToString();

            return result;
        }
    }
}
