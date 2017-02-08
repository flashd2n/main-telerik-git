using System;

namespace MainProject
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Filename cannot be empty.");
            }

            if (!fileName.EndsWith(".SLF", System.StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            WasLastFileNameValid = true;
            return true;

        }


    }
}
