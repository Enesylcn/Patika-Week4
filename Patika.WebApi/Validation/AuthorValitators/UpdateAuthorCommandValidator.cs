using FluentValidation;
using Patika.WebApi.Application.AuthorOperations.Commands.UpdateAuthor;

namespace Patika.WebApi.Validation
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4).When(x => x.Model.Name != string.Empty);
        }
    }
}
