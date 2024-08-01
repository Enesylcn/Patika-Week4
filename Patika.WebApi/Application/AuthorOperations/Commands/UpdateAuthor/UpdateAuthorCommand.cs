using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Patika.WebApi.DBOperations;

namespace Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _context;

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Author not found!");

            if (_context.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException("An author with the same name already exists!");

            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            _context.SaveChanges();
        }
        public class UpdateAuthorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }

}