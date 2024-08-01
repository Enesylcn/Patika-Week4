using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using Patika.WebApi.Validation;
using TestSetup;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(12)]
        [InlineData(14)]
        [InlineData(23)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int authorId)
        {
            //Arrange 
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId = authorId;
            //Act 
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().Be(0);

        }
    }
}