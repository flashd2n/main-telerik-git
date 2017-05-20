using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WritingXmlStAxSax
{
    class Startup
    {
        static void Main()
        {
            var myBooks = new List<Book>()
            {
                new Book(1, "Title One"),
                new Book(2, "Title Two"),
                new Book(3, "Title Three")
            };

            using (var writer = XmlWriter.Create("../../output.xml"))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("books");

                foreach (var book in myBooks)
                {
                    WriteNextBook(writer, book);
                }

                writer.WriteEndElement();
                
                writer.WriteEndDocument();
            }
        }

        static void WriteNextBook(XmlWriter writer, Book book)
        {
            writer.WriteStartElement("book");

            writer.WriteAttributeString("id", book.Id.ToString());

            writer.WriteElementString("title", book.Title);

            writer.WriteEndElement();
        }
    }
}