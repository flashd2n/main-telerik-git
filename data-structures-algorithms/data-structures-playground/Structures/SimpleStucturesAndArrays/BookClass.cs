using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStucturesAndArrays
{
    public class BookClass
    {
        public BookClass(int id, string title, string author)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
