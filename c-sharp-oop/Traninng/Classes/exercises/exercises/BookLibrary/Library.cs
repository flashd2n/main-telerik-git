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
        private List<Book> collection = new List<Book>();
        private static int usedSpaces;
        
        public Library(string name)
        {
            this.Name = name;
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
        }

        public void AddToLibrary(Book book)
        {
            this.collection.Add(book);
            ++usedSpaces;
        }

        public void RemoveFromLibrary(int index)
        {
            
            for (int i = index; i < Collection.Count - 1; i++)
            {
                collection[i] = collection[i + 1];
            }
            collection[Collection.Count - 1] = null;
            --usedSpaces;
        }

        public Book SearchAuthor(string author)
        {
            var foundBook = new Book();
            for (int i = 0; i < collection.Count; i++)
            {
                if (author == collection[i].Author)
                {
                    foundBook = collection[i];
                }
            }
            return foundBook;
        }

        public void DisplayInfoBook(int index)
        {
            Console.WriteLine($"Title: {collection[index].Title}\nAuthor: {collection[index].Author}\nPublisher: {collection[index].Publisher}\nRelease Date: {collection[index].ReleaseDate}\nISBN: {collection[index].ISBN}");
        }

    }
}
