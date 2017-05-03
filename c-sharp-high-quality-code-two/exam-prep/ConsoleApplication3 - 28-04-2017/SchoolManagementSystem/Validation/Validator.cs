using SchoolManagementSystem.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SchoolManagementSystem.Validation
{
    public class Validator : IValidator
    {
        public void ValidateString(string textToValidate, int minLength, int maxLength, string errorMessage)
        {
            var textToVallidateLength = textToValidate.Length;

            var isInvalidLength = textToVallidateLength < minLength || textToVallidateLength > maxLength;
            var hasNonLatinChars = !Regex.IsMatch(textToValidate, @"^[a-zA-Z]+$");

            if (isInvalidLength || hasNonLatinChars)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
