using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class User : IUser
    {
        public User(string username, string email)
        {
            this.Name = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email { get; set; }

        public override string ToString()
        {
            var userInformation = new StringBuilder();

            userInformation.AppendLine("    Username: " + this.Name);
            userInformation.AppendLine("    Email: " + this.Email);

            var result = userInformation.ToString();

            return result;
        }
    }
}
