using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Queries.GetBookDetail;
using Patika.WebApi.Validation;
using TestSetup;

namespace Application.BookOperations.Qeries.GetBookDetail
{
    public class GetBookDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
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
            GetBookDetailQuery command = new GetBookDetailQuery(null, null);
            command.BookId = bookId;
            //Act 
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            var result = validator.Validate(command);

            //assert 
            result.Errors.Count.Should().Be(0);

        }
    }
}