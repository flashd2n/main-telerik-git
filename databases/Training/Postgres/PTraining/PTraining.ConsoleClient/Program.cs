using PTraining.Data;
using PTraining.Models;
using PTraining.Models.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTraining.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new BloggingEntities();


            var blogEntry = new Blog
            {
                Name = "wow"
            };

            dbContext.Blogs.Add(blogEntry);
            dbContext.SaveChanges();

            var sqlDbContext = new SqlServerEntities();

            var book = new Book
            {
                Title = "gone with the wind"
            };

            sqlDbContext.Books.Add(book);
            sqlDbContext.SaveChanges();
        }
    }
}