using Microsoft.EntityFrameworkCore;
using Patika.WebApi.Entities;

namespace Patika.WebApi.DBOperations
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }

        int SaveChanges();



    }
}