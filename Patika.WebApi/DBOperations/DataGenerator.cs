using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patika.WebApi.Entities;

namespace Patika.WebApi.DBOperations
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange
                (
                   new Genre
                   {
                       Name = "Personal Growth"
                   },
                   new Genre
                   {
                       Name = "Science Fiction"
                   },
                   new Genre
                   {
                       Name = "Romance"
                   }
               );
                context.Books.AddRange
                (
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1, // Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 6, 12),
                        AuthorId = 1
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2, // Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 5, 23),
                        AuthorId = 2
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 2, // Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21),
                        AuthorId = 3
                    }
                );
                context.Authors.AddRange
                (
                   new Author
                   {
                       Name = "Eric",
                       Surname = "Ries",
                       BirthDate = new DateTime(1978, 12, 9),

                   },
                   new Author
                   {
                       Name = "Charlotte",
                       Surname = "Perkins Stetson Gilm",
                       BirthDate = new DateTime(1860, 8, 18),
                   },
                   new Author
                   {
                       Name = "Frank",
                       Surname = "Herbert",
                       BirthDate = new DateTime(1920, 10, 1),
                   }
               );
                context.SaveChanges();
            }


        }
    }
}