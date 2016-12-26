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
            var bookOne = new Book("Book One", "Some Author", "That Publisher", new DateTime(2016, 11, 21), "32-4-541-12-3");
            var bookTwo = new Book("Book Two", "Some Other Author", "That Publisher", new DateTime(2004, 11, 21), "32-4-541-12-3");
            var bookThree = new Book("Book Three", "Random Author");
            var bookFour = new Book("Book Four", "Test Author", "That Test Publisher", new DateTime(2016, 11, 21));
            var bookFive = new Book("Book Five", "RND Author", "Publisher", new DateTime(2016, 11, 21), "32-4-541-12-3");


        }
    }
}
