using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patika.WebApi.DBOperations;

namespace Patika.WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly IBookStoreDbContext _context;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Book not found");
            }
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;

            _context.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int AuthorId { get; set; }

        }
    }
}