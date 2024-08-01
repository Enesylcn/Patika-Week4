using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Commands.UpdateBook;
using Patika.WebApi.Application.GenreOperations.Commands.UpdateGenre;
using Patika.WebApi.Validation;
using TestSetup;
using static Patika.WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static Patika.WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData(1, "Romance", true)]
        [InlineData(4, "Roman", true)]
        [InlineData(5, "Fantastic", true)]
        [InlineData(6, "Sad", false)]
        [InlineData(6, " ", true)]
        [InlineData(7, "Horror", true)]
        [InlineData(12, "Scientifiction", true)]
        [InlineData(1, "Romance", false)]


        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int genreId, string name, bool isActive)
        {
            //Arrange 
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.GenreId = genreId;
            command.Model = new UpdateGenreModel()
            {
                Name = name,
                IsActive = isActive
            };

            //Act 
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}