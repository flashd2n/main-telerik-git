using System;
using System.Text.RegularExpressions;

namespace SchoolManagementSystem.Models
{
    public class Person
    {
        private const int MinStringLength = 2;
        private const int MaxStringLength = 31;
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateString(value, MinStringLength, MaxStringLength, "The student's first name is not valid");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateString(value, MinStringLength, MaxStringLength, "The student's first name is not valid");
                this.lastName = value;
            }
        }

        private void ValidateString(string textToValidate, int minLength, int maxLength, string errorMessage)
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
