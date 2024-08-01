using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Commands.UpdateBook;
using Patika.WebApi.DBOperations;
using TestSetup;
using static Patika.WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var bookId = 4;
            UpdateBookModel Model = new UpdateBookModel()
            {
                Title = "WhenNotExistBookIdIsGiven_InvalidOperation_ShouldBeReturn",
                GenreId = 10,
                AuthorId = 20
            };

            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = bookId;
            command.Model = Model;

            var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
            //Act & assert 
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found");

        }
    }
}