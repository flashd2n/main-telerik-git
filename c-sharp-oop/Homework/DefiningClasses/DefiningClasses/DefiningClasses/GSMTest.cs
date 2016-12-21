using System;

namespace DefiningClasses
{
    class GSMTest
    {
        public static void TestGSM()
        {
            // Create an array of few instances of the GSM class.

            var arrayOfGsms = new GSM[3];

            for (int i = 0; i < 3; i++)
            {
                arrayOfGsms[i] = new GSM("iphone", "Apple");
            }

            // Display the information about the GSMs in the array.

            foreach (var phone in arrayOfGsms)
            {
                phone.ShowInfo();
            }
            Console.WriteLine("=====");

            // Display the information about the static property IPhone4S

            GSM.IPhone4S.ShowInfo();
        }
    }
}
