using AutoMapper;
using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using Patika.WebApi.DBOperations;
using Patika.WebApi.Entities;
using TestSetup;
using static Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var author = new Author() { Name = "Test_WhenAlreadyExistAuthorTitleIsGiven_InvalidOperation_ShouldBeReturn", Surname = "Surname", BirthDate = DateTime.Now.Date.AddYears(-2) };
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = new CreateAuthorModel() { Name = author.Name, Surname = author.Surname, DateOfBirth = author.BirthDate };

            //Act & assert 
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author already exists");

        }

    }
}