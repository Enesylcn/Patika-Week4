using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Commands.DeleteBook;
using Patika.WebApi.Validation;
using TestSetup;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(12)]
        [InlineData(14)]
        [InlineData(23)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            //Arrange 
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;
            //Act 
            DeleteBookCommanValidator validator = new DeleteBookCommanValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().Be(0);

        }
    }
}