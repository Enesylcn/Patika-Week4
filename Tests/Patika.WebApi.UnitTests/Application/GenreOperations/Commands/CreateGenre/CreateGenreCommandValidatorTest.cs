using AutoMapper;
using FluentAssertions;
using Patika.WebApi;
using Patika.WebApi.Application.BookOperations.Commands.CreateBook;
using Patika.WebApi.Application.GenreOperations.Commands.CreateGenre;
using Patika.WebApi.DBOperations;
using Patika.WebApi.Validation;
using TestSetup;
using static Patika.WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData("Romance")]
        [InlineData("r")]
        [InlineData("2")]
        [InlineData("Sad")]
        [InlineData(".")]
        [InlineData("as")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            //Arrange 
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel()
            {
                Name = name
            };

            //Act 
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}