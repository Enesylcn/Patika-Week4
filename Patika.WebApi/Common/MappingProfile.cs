using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using static Patika.WebApi.BookOperations.CreateBook.CreateBookCommand;
using static Patika.WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static Patika.WebApi.BookOperations.GetBooks.GetBooksQuery;

namespace Patika.WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        }
    }
}