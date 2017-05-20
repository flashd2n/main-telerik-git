using System;

namespace ProcessingXmlSAXStAX
{
    public class Book
    {
        public Book(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public void Print()
        {
            Console.WriteLine(string.Format($"Book id: {this.Id} | Book title: {this.Title}"));
        }
    }
}
