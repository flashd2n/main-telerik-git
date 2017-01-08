using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Startup
    {
        static void Main()
        {
            var myLibrary = new Library("My Library");
            var bookOne = new Book("Book One", "Stephen King", "That Publisher", new DateTime(2016, 11, 21), "32-4-541-12-3");
            var bookTwo = new Book("Book Two", "Some Other Author", "That Publisher", new DateTime(2004, 11, 21), "32-4-541-12-3");
            var bookThree = new Book("Book Three", "Stephen King");
            var bookFour = new Book("Book Four", "Test Author", "That Test Publisher", new DateTime(2016, 11, 21));
            var bookFive = new Book("Book Five", "Stephen King", "Publisher", new DateTime(2016, 11, 21), "32-4-541-12-3");
            myLibrary.AddToLibrary(bookOne);
            myLibrary.AddToLibrary(bookTwo);
            myLibrary.AddToLibrary(bookThree);
            myLibrary.AddToLibrary(bookFour);
            myLibrary.AddToLibrary(bookFive);

            //for (int i = 0; i < myLibrary.Collection.Count; i++)
            //{
            //    myLibrary.DisplayInfoBook(i);
            //    Console.WriteLine("======");
            //}

            for (int i = 0; i < myLibrary.Collection.Count; i++)
            {
                if (myLibrary.Collection[i] == null)
                {
                    continue;
                }

                if (myLibrary.Collection[i].Author == "Stephen King")
                {
                    myLibrary.RemoveFromLibrary(i);
                    --i;
                }
            }

            for (int i = 0; i < myLibrary.Collection.Count; i++)
            {
                if (myLibrary.Collection[i] == null)
                {
                    continue;
                }

                myLibrary.DisplayInfoBook(i);
                Console.WriteLine("======");
            }
        }
    }
}
