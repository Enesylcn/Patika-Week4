using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patika.WebApi.Common;
using Patika.WebApi.DBOperations;

namespace Patika.WebApi.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Book not found");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            return vm;
        }

        public class BookDetailViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}