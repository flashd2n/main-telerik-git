using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listsDemo
{
    class lists
    {
        static void Main(string[] args)
        {

            List<int> myList = new List<int>()/* { 1, 2, 3, 4, 5}*/;



            //myList[2] = 100;


            //foreach (int x in myList)
            //{
            //    Console.WriteLine(x);
            //}

            //for (int i = 0; i < myList.Count; i++)
            //{
            //    myList[i] *= 2;
            //    Console.WriteLine(myList[i]);
            //}

            //Console.WriteLine(myList.Count);

            //myList.Add(5);

            //Console.WriteLine(myList.Count);

            //for (int i = 0; i < 1000; i++)
            //{
            //    myList.Add(5);
            //}

            //Console.WriteLine(string.Join(" ", myList));


            for (int i = 1; i <= 10; i++)
            {
                myList.Add(i);
            }



            Console.WriteLine(string.Join(" ", myList));

            myList.Remove(3);
            //myList.RemoveAll((x) => x == 3); --> removes all "3"
            //myList.RemoveAt(myList.Count - 1); ---> fastest deletion in a list
            //myList.Contains(7); ---> returns boolean if the value exists in the list

            Console.WriteLine(string.Join(" ", myList));

            


        }
    }
}
