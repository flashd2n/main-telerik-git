using System;
using System.Collections.Generic;
using System.Xml;

namespace ProcessingXmlSAXStAX
{
    class Startup
    {
        static void Main()
        {
            var myBooks = new List<Book>();
            
            using (var node = XmlReader.Create("../../data/XmlData.xml"))
            {
                while (node.Read())
                {
                    if (node.IsStartElement() && node.Name == "book")
                    {
                        var newBook = GetBook(node);
                        myBooks.Add(newBook);
                    }
                }
            }

            foreach (var book in myBooks)
            {
                book.Print();
            }
        }

        static Book GetBook(XmlReader node)
        {
            var bookId = int.Parse(node.GetAttribute("id"));

            node.ReadToDescendant("title");
            node.Read();

            var bookTitle = node.Value;
            
            return new Book(bookId, bookTitle);
        }
    }
}
