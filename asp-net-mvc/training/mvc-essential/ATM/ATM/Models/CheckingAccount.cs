using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Account #")]
        [RegularExpression(@"^[a-zA-Z0-9]{6,10}$", ErrorMessage = "Account # must be between 6 and 10 digits")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return String.Format($"{this.FirstName} {this.LastName}"); }
        }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }
    }
}