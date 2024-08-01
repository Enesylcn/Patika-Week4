using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using Patika.WebApi.Validation;
using TestSetup;
using static Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData(3, "Frank", "Herbert", "1920-10-01")]
        [InlineData(4, "Ali", "Veli", "1999-10-29")]
        [InlineData(12, "Ali", "Veli", "1999-10-29")]
        [InlineData(1, "Ali", "Veli", "1999-10-29")]
        [InlineData(2, "Ali", "Veli", "1999-10-29")]
        [InlineData(3, "Ali", "Veli", "1999-10-29")]
        [InlineData(5, "Ali", "Veli", "1999-10-29")]
        [InlineData(8, "Ali", "Veli", "1999-10-29")]



        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int authorId, string name, string surname, string date)
        {
            //Arrange 
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.AuthorId = authorId;
            command.Model = new UpdateAuthorModel()
            {
                Name = name,
                Surname = surname,
                DateOfBirth = DateTime.Parse(date)
            };

            //Act 
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}