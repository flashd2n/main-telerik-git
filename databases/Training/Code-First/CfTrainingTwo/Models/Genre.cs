using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Genre
    {
        private ICollection<Book> books;
        private ICollection<Genre> childGenres;

        public Genre()
        {
            this.books = new HashSet<Book>();
            this.childGenres = new HashSet<Genre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public virtual Genre ParentGenre { get; set; }

        public virtual ICollection<Genre> ChildGenres
        {
            get { return this.childGenres; }
            set { this.childGenres = value; }
        }
    }
}
