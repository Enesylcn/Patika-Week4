using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Patika.WebApi.Application.BookOperations.Commands.CreateBook;
using Patika.WebApi.Application.BookOperations.Commands.DeleteBook;
using Patika.WebApi.Application.BookOperations.Queries.GetBookDetail;
using Patika.WebApi.Application.BookOperations.Queries.GetBooks;
using Patika.WebApi.Application.BookOperations.Commands.UpdateBook;
using Patika.WebApi.DBOperations;
using Patika.WebApi.Validation;
using static Patika.WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static Patika.WebApi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static Patika.WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Patika.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);

            query.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            command.Model = newBook;
            CreateBookCommanValidator createBookCommanValidator = new CreateBookCommanValidator();
            createBookCommanValidator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            DeleteBookCommand command = new DeleteBookCommand(_context);

            command.BookId = id;
            DeleteBookCommanValidator deleteBookCommanValidator = new DeleteBookCommanValidator();
            deleteBookCommanValidator.ValidateAndThrow(command);
            command.Handle();

            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);

            command.BookId = id;
            command.Model = updatedBook;

            UpdateBookCommandValidator updateBookCommandValidator = new UpdateBookCommandValidator();
            updateBookCommandValidator.ValidateAndThrow(command);
            command.Handle();

            _context.SaveChanges();
            return Ok();
        }

    }
}