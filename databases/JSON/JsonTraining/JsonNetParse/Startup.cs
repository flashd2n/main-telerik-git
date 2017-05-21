using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNetParse
{
    public class Startup
    {
        static void Main()
        {
            var json = @"{""Id"":2,""Title"":""Awesome title"",""Description"":""Cool Description"",""Genres"":[""Fantasy"",""Action""]}";

            var myBook = JsonConvert.DeserializeObject<Book>(json);

            Console.WriteLine(myBook);

            var newJson = JsonConvert.SerializeObject(myBook);

            Console.WriteLine(newJson);

            // anon

            var person = new
            {
                Name = "Gosho",
                Age = 19
            };

            var personJson = JsonConvert.SerializeObject(person);

            var tempate = new { Name = "", Age = 0 };

            var personTwo = JsonConvert.DeserializeAnonymousType(personJson, tempate);

            Console.WriteLine(personTwo);



        }
    }
}
