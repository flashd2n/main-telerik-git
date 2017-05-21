using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstParseJson
{
    public class Book
    {
        public Book()
        {

        }

        public Book(int id, string title, string description, params string[] genres)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Genres = genres;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public override string ToString()
        {
            return $"Book id: {this.Id} | Book title: {this.Title} | Book Description: {this.Description} | Book Genres: {string.Join(", ", this.Genres)}";
        }
    }
}
