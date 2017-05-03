using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Interfaces
{
    public interface IValidator
    {
        void ValidateString(string textToValidate, int minLength, int maxLength, string errorMessage);
    }
}
