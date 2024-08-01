using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Commands.DeleteBook;
using Patika.WebApi.DBOperations;
using TestSetup;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var bookId = 4;
            var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
            _context.Books.Remove(book);
            _context.SaveChanges();
            //Act & assert 
            DeleteBookCommand command = new DeleteBookCommand(_context);

            command.BookId = bookId;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found");

        }
    }
}