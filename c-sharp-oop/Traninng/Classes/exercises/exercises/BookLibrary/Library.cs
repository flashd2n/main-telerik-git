using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Library
    {
        private string name;
        private List<Book> collection;
        
        public Library(string name)
        {
            this.Name = name;
            List<Book> collection = new List<Book>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
        public List<Book> Collection
        {
            get
            {
                return this.collection;
            }

            private set
            {
                this.collection = value;
            }
        }

        public void AddToLibrary(Book book)
        {
            this.collection.Add(book);
        }

        public void RemoveFromLibrary(int index)
        {
            Collection[index] = null;
            for (int i = index; i < Collection.Count - 1; i++)
            {
                Collection[i] = Collection[i + 1];
            }

        }

        public Book SearchAuthor(string author)
        {
            var foundBook = new Book();
            for (int i = 0; i < collection.Count; i++)
            {
                if (author == Collection[i].Author)
                {
                    foundBook = Collection[i];
                }
            }
            return foundBook;
        }

        public void DisplayInfoBook(Book book)
        {
            Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}\nPublisher: {book.Publisher}\nRelease Date: {book.ReleaseDate}\nISBN: {book.ISBN}");
        }

    }
}
