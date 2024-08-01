using FluentAssertions;
using Patika.WebApi.Application.GenreOperations.Commands.DeleteGenre;
using Patika.WebApi.Validation;
using TestSetup;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(12)]
        [InlineData(14)]
        [InlineData(23)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int genreId)
        {
            //Arrange 
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = genreId;
            //Act 
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}