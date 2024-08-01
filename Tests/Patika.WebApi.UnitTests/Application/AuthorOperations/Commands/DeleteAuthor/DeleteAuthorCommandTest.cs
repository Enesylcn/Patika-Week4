using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using Patika.WebApi.DBOperations;
using TestSetup;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistAuthorIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var authorId = 4;
            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            _context.Authors.Remove(author);
            _context.SaveChanges();
            //Act & assert 
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

            command.AuthorId = authorId;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author not found!");

        }
    }
}