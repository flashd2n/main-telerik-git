namespace MainProject
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {

            if (!fileName.EndsWith(".SLF", System.StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            return true;

        }


    }
}
