using FluentValidation;
using Patika.WebApi.Application.GenreOperations.Queries.GetGenreDetail;

namespace Patika.WebApi.Validation
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);

        }
    }
}
