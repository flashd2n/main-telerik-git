using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStucturesAndArrays
{
    public class Startup
    {
        static void Main()
        {
            // Testing Structs

            var bookStruct = new BookStruct(1, "title one", "author one");

            Console.WriteLine("---- STRUCT ----");

            Console.WriteLine($"Before change attempt: {bookStruct.Id}");

            ChangeId(bookStruct);

            Console.WriteLine($"After change attempt: {bookStruct.Id}");

            Console.WriteLine("---- Class ----");

            var bookClass = new BookClass(1, "title one", "author one");

            Console.WriteLine($"Before change attempt: {bookClass.Id}");

            ChangeId(bookClass);

            Console.WriteLine($"After change attempt: {bookClass.Id}");
            
        }

        public static void ChangeId(BookStruct book)
        {
            book.Id = 5;
        }

        public static void ChangeId(BookClass book)
        {
            book.Id = 5;
        }
    }
}
