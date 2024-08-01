using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patika.WebApi.Common;
using Patika.WebApi.DBOperations;
using Patika.WebApi.Entities;

namespace Patika.WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x => x.Id).ToList<Author>(); ;
            List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(authorList);
            return vm;
        }

        public class AuthorViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            public DateTime BirthDate { get; set; }
        }
    }
}
