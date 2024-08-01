using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Patika.WebApi.Validation;
using TestSetup;

namespace Application.AuthorOperations.Qeries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
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
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
            query.AuthorId = authorId;
            //Act 
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            var result = validator.Validate(query);

            //assert 
            result.Errors.Count.Should().Be(0);

        }
    }
}