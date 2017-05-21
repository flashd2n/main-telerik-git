using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FirstParseJson
{
    public class Startup
    {
        static void Main()
        {
            var myBook = new Book(1, "Awesome title", "Cool Description", "Fantasy", "Action");

            var serializer = new JavaScriptSerializer();

            var json = serializer.Serialize(myBook);

            Console.WriteLine(json);

            //Console.WriteLine(myBook);


            var myDict = new Dictionary<string, Book>();

            for (int i = 0; i < 10; i++)
            {
                myDict[$"{i}"] = myBook;
            }

            //Console.WriteLine(serializer.Serialize(myDict));


            // deserialize

            var myBookTwo = serializer.Deserialize<Book>(json);

            Console.WriteLine(myBookTwo);


        }
    }
}
