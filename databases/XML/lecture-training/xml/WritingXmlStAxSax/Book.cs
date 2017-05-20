using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingXmlStAxSax
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
