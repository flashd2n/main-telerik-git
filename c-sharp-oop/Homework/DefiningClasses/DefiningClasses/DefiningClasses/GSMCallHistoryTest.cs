using System;

namespace DefiningClasses
{
    class GSMCallHistoryTest
    {
        public static void CallTest()
        {
            // Create an instance of the GSM class.

            var newPhone = new GSM("test model", "random manufacturer");

            // Add few calls.

            newPhone.AddCall(DateTime.Now, 500, "0888424124");
            newPhone.AddCall(new DateTime(2016, 12, 31, 23, 58, 59), 1600, "0888444444");
            newPhone.AddCall(new DateTime(2016, 12, 21, 11, 23, 01), 2600, "0888444333");

            // Display the information about the calls.

            PrintCallHistory(newPhone);

            // Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
            // price is set as a constant in GSM class

            var totalPrice = newPhone.CalculateCallsPrice();
            Console.WriteLine("You must pay: {0:F2} leva", totalPrice);

            // Remove the longest call from the history and calculate the total price again.

            int longestCall = 0;
            int indexLongestCall = 0;

            for (int i = 0; i < newPhone.CallHistory.Count; i++)
            {
                if (newPhone.CallHistory[i].Duration > longestCall)
                {
                    longestCall = newPhone.CallHistory[i].Duration;
                    indexLongestCall = i;
                }

            }

            newPhone.DeleteCall(indexLongestCall);

            var newPrice = newPhone.CalculateCallsPrice();
            Console.WriteLine("You must pay: {0:F2} leva", newPrice);


            // Finally clear the call history and print it.

            newPhone.ClearHistory();
            PrintCallHistory(newPhone);
        }

        static void PrintCallHistory(GSM newPhone)
        {
            if (newPhone.CallHistory.Count == 0)
            {
                Console.WriteLine("No Calls");
            }

            for (int i = 0; i < newPhone.CallHistory.Count; i++)
            {
                Console.WriteLine($"Call number {i} happened on: {newPhone.CallHistory[i].DateAndTime}, it lasted: {newPhone.CallHistory[i].Duration} seconds and the conacted number was: {newPhone.CallHistory[i].DialledNumber}");
            }
        }

    }
}
