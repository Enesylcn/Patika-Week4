using AutoMapper;
using FluentAssertions;
using Patika.WebApi;
using Patika.WebApi.Application.BookOperations.Commands.CreateBook;
using Patika.WebApi.DBOperations;
using Patika.WebApi.Validation;
using TestSetup;
using static Patika.WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord Of The Rings", 0, 0)]
        [InlineData("Lord Of The Rings", 0, 1)]
        [InlineData("Lord Of The Rings", 100, 0)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 100, 0)]
        [InlineData("Lord", 0, 1)]
        [InlineData(" ", 100, 1)]
        // [InlineData("Lord Of The Rings", 100, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            //Arrange 
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = genreId
            };

            //Act 
            CreateBookCommanValidator validator = new CreateBookCommanValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenDatetimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //Arrange 
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date,
                GenreId = 1
            };

            CreateBookCommanValidator validator = new CreateBookCommanValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //Arrange 
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(-2),
                GenreId = 1
            };

            CreateBookCommanValidator validator = new CreateBookCommanValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }



    }
}