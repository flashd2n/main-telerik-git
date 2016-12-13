using System;

namespace lectureIntro
{
    class intro
    {
        static void TestMethod (string text, int repeat)
        {


            for (int i = 0; i < repeat; i++)
            {
                Console.WriteLine(text);
            }

            

        }

        static void Main()
        {
            TestMethod("printing", 5);
            TestMethod("more printing", 10);


        }
    }
}
