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
using Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using Patika.WebApi.Entities;
using static Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static Patika.WebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static Patika.WebApi.Application.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;

namespace Patika.WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Book, BookViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();





        }
    }
}