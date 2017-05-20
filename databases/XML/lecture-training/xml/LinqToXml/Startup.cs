using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXml
{
    class Startup
    {
        static void Main()
        {
            //var doc = XDocument.Load("../../data/XmlData.xml");

            //var books = doc.Root
            //               .Elements("book")
            //               .Select(node =>
            //               {
            //                   var id = int.Parse(node.Attribute("id").Value);
            //                   var title = node.Element("title").Value;

            //                   return new Book(id, title);
            //               })
            //               .ToList();

            //foreach (var book in books)
            //{
            //    book.Print();
            //}

            var myBooks = new List<Book>()
            {
                new Book(1, "Title One"),
                new Book(2, "Title Two"),
                new Book(3, "Title Three")
            };

            var doc = new XDocument();

            var root = new XElement("books",
                myBooks.Select(book => new XElement("book",
                    new XAttribute("id", book.Id),
                    new XElement("title", book.Title)
                )));

            var root2 = new XElement("books",
                myBooks.Select(book => new XElement("book",
                    new XAttribute("id", book.Id),
                    new XElement("title", book.Title)
                    )
                ));

            root.Add(root2);

            doc.Add(root);

            doc.Save("../../linqoutput.xml");

        }
    }
}
