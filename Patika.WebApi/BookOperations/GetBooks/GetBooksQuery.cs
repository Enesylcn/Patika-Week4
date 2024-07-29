using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patika.WebApi.Common;
using Patika.WebApi.DBOperations;

namespace Patika.WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;
        public GetBooksQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<BookViewModel> Handle()
        {
            var booksList = _context.Books.OrderBy(x => x.Id).ToList<Book>();

            List<BookViewModel> vm = new List<BookViewModel>();

            foreach (var book in booksList)
            {
                vm.Add(new BookViewModel()
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    Genre = ((GenreEnum)book.GenreId).ToString()
                });
            }

            return vm;
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
