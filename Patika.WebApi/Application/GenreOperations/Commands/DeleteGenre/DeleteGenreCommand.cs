using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Patika.WebApi.DBOperations;

namespace Patika.WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {

        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is not null)
                throw new InvalidOperationException("Kitap türü Bulunamadı!");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }

}