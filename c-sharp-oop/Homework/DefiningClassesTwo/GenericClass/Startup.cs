using System;

namespace GenericClass
{
    class Startup
    {
        static void Main()
        {
            var myList = new GenericList<int>(4);

            myList.Add(54);
            myList.Add(23);
            Console.WriteLine(myList[0]);
            myList.RemoveByIndex(0);
            myList.Print();
            myList.InsertItem(0, 22);
            myList.Print();
            Console.WriteLine(myList.IndexOf(22));
            myList.Add(3);
            myList.Add(33);
            myList.Add(321);
            Console.WriteLine(myList);

            Console.WriteLine(myList.Min());

            myList.Clear();
            Console.WriteLine(myList);

            Console.WriteLine("==== new test");


            var newlist = new GenericList<int>(4);
            newlist.Add(43);
            newlist.Add(32);
            newlist.Add(23);
            newlist.Add(54);
            Console.WriteLine(newlist.Min());

        }
    }
}
