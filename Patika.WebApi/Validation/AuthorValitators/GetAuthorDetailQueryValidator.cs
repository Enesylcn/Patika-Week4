using FluentValidation;
using Patika.WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Patika.WebApi.Application.GenreOperations.Queries.GetGenreDetail;

namespace Patika.WebApi.Validation
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);

        }
    }
}
