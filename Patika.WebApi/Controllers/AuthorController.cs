using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Patika.WebApi.DBOperations;
using Patika.WebApi.Application.AuthorOperations.Queries.GetAuthors;
using static Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using Patika.WebApi.Validation.AuthorValitators;
using Patika.WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using Patika.WebApi.Validation;
using Patika.WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using static Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor;

namespace Patika.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);

        }


        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);

            command.Model = newAuthor;
            CreateAuthorCommandValidator createBookCommanValidator = new CreateAuthorCommandValidator();
            createBookCommanValidator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = updateAuthor;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            _context.SaveChanges();
            return Ok();
        }

    }
}