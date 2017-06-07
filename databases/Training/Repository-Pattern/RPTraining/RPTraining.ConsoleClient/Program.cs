using RPTraining.Data;
using RPTraining.Data.Repositories;
using RPTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTraining.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var db = new MyDbContext();

            // --------------------

            var authors = db.Authors;

            Console.WriteLine(authors.Count());

            // --------------------

            var authorsRepository = new EfRepository<Author>(db);

            var allAuthors = authorsRepository.All();

            Console.WriteLine(allAuthors.Count());

            authorsRepository.Add(new Author
            {
                FullName = "Gosho"
            });

            authorsRepository.SaveChanges();
        }
    }
}
