using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToJson
{
    class Startup
    {
        static void Main()
        {
            var myBooks = new List<Book>();

            for (int i = 0; i < 15; i++)
            {
                myBooks.Add(new Book(i, "Title-" + i, "Description-" + i));
            }

            var json = JsonConvert.SerializeObject(myBooks, Formatting.Indented);

            Console.WriteLine(json);

            JArray.Parse(json)
                .Where(jObj => jObj["Title"].Value<string>().Contains("1"))
                .Select(jObj => jObj["Title"].ToString())
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
