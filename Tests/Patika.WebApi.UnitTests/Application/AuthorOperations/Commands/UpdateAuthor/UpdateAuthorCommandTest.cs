using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using Patika.WebApi.DBOperations;
using TestSetup;
using static Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistAuthorIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var authorId = 4;
            UpdateAuthorModel Model = new UpdateAuthorModel()
            {
                Name = "WhenAlreadyExistAuthorNameIsGiven_InvalidOperation_ShouldBeReturn",
                Surname = "WhenAlreadyExistAuthorNameIsGiven_InvalidOperation_ShouldBeReturn",
                DateOfBirth = DateTime.Now.Date.AddDays(-20)
            };

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = authorId;
            command.Model = Model;

            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            //Act & assert 
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author not found!");


        }

    }
}