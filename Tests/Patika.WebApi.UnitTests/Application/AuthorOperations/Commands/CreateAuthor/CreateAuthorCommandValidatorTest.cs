using AutoMapper;
using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using Patika.WebApi.Validation;
using Patika.WebApi.Validation.AuthorValitators;
using TestSetup;
using static Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData("Frank", "Herbert", "1920-10-01")]

        [InlineData("Ali", "Veli", "1999-10-29")]
        [InlineData("al", "Ks", "1999-10-29")]
        [InlineData("al", "V", "1999-10-29")]
        [InlineData("Ali3", "V", "1999")]
        [InlineData("Ali4", "Ve", "2025-10-29")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string date)
        {
            //Arrange 
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel()
            {
                Name = name,
                Surname = surname,
                DateOfBirth = DateTime.Parse(date)
            };

            //Act 
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}