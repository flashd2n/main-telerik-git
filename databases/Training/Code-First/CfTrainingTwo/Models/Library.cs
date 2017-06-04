using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Library
    {
        private ICollection<Book> books;

        public Library()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
