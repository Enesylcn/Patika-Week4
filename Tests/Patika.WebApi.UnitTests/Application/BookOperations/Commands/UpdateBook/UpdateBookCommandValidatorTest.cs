using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Commands.UpdateBook;
using Patika.WebApi.Validation;
using TestSetup;
using static Patika.WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lean Startup", 0, 0, 0)]
        [InlineData("Herland", 0, 3, 0)]
        [InlineData("Dune", 2, 3, 0)]
        [InlineData(" ", 1, 2, 3)]
        [InlineData("", 43, 43, 43)]
        [InlineData("du", 3, 2, 1)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int bookId, int genreId, int authorId)
        {
            //Arrange 
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.BookId = bookId;
            command.Model = new UpdateBookModel()
            {
                Title = title,
                GenreId = genreId,
                AuthorId = authorId
            };

            //Act 
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}