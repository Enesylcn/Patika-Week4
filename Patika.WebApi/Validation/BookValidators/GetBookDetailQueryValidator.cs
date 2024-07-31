using FluentValidation;
using Patika.WebApi.Application.BookOperations.Queries.GetBookDetail;


namespace Patika.WebApi.Validation
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);

        }
    }
}
