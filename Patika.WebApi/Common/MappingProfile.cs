using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using static Patika.WebApi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static Patika.WebApi.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static Patika.WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static Patika.WebApi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static Patika.WebApi.Application.BookOperations.Queries.GetBooks.GetBooksQuery;

namespace Patika.WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();


        }
    }
}