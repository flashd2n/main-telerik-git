using System;

namespace GenericClass
{
    class Program
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


        }
    }
}
