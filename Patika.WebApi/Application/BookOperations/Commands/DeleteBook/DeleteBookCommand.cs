using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patika.WebApi.DBOperations;

namespace Patika.WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _context;

        public int BookId { get; set; }
        public DeleteBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Book not found");
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}