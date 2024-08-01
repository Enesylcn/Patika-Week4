using AutoMapper;
using FluentAssertions;
using Patika.WebApi;
using Patika.WebApi.Application.BookOperations.Commands.CreateBook;
using Patika.WebApi.DBOperations;
using TestSetup;
using static Patika.WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTestFixture testFixture)
        {
            _mapper = testFixture.Mapper;
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperation_ShouldBeReturn", PageCount = 100, PublishDate = new System.DateTime(1998, 01, 10), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //Act & assert 
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book already exists");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldNotBeCreated()
        {
            //Arrange 
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel()
            {
                Title = "Hobbit",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(-12),
                GenreId = 1,
                AuthorId = 3
            };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(b => b.Title == model.Title);

            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.AuthorId.Should().Be(model.AuthorId);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);

        }
    }
}