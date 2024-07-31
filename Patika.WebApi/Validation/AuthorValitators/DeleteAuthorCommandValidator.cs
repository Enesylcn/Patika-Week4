using FluentValidation;
using Patika.WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

namespace Patika.WebApi.Validation
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
