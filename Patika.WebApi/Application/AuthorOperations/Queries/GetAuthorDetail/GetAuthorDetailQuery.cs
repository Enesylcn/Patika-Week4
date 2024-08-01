using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Patika.WebApi.Common;
using Patika.WebApi.DBOperations;

namespace Patika.WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {

        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Author not found!");

            return _mapper.Map<AuthorDetailViewModel>(author);
        }

        public class AuthorDetailViewModel
        {
            public string Name { get; set; }
            public string SurName { get; set; }

            public DateTime DateOfBirth { get; set; }

        }
    }
}
