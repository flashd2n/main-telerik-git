using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public interface IUser
    {
        [Required(ErrorMessage = "User Username is required!")]
        string Name { get; set; }

        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        string Email { get; set; }
    }
}
