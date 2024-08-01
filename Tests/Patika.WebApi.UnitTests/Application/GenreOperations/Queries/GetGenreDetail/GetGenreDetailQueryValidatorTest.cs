using FluentAssertions;
using Patika.WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using Patika.WebApi.Validation;
using TestSetup;

namespace Application.GenreOperations.Qeries.GetGenreDetail
{
    public class GetGenreDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
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
            GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
            query.GenreId = genreId;
            //Act 
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            //assert 
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}