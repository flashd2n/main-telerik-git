using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Book
    {
        private string title;
        private string author;
        private string publisher;
        private DateTime releaseDate;
        private string isbn;

        public Book() : this (default(string))
        {
        }
        public Book(string title) : this (title, default(string))
        {
        }
        public Book(string title, string author) : this (title, author, default(string))
        {
        }
        public Book(string title, string author, string publisher) : this(title, author, publisher, default(DateTime))
        {
        }
        public Book(string title, string author, string publisher, DateTime releaseDate) : this(title, author, publisher, releaseDate, default(string))
        {
        }
        public Book(string title, string author, string publisher, DateTime releaseDate, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                this.title = value;
            }
        }
        public string Author
        {
            get
            {
                return this.author;
            }
            private set
            {
                this.author = value;
            }
        }
        public string Publisher
        {
            get
            {
                return this.publisher;
            }
            private set
            {
                this.publisher = value;
            }
        }
        public DateTime ReleaseDate
        {
            get
            {
                return this.releaseDate;
            }
            private set
            {
                this.releaseDate = value;
            }
        }
        public string ISBN
        {
            get
            {
                return this.isbn;
            }
            private set
            {
                this.isbn = value;
            }
        }

    }
}
