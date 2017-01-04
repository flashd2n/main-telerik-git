using System;
using System.Reflection;

namespace CustomAttribute
{
    class Startup
    {
        static void Main()
        {
            var sampleTest = new Sample();

            Console.WriteLine(sampleTest.GetType().GetCustomAttribute<Version>().FullVersion);
        }
    }

    [Version(2.11)]
    public class Sample
    {

    }
}
