using System;

namespace DefiningClasses
{
    class YouCanAccessTheTestingClassesHere
    {
        static void Main()
        {
            GSMTest.TestGSM();

            Console.WriteLine("=============");

            GSMCallHistoryTest.CallTest();
        }
    }
}
