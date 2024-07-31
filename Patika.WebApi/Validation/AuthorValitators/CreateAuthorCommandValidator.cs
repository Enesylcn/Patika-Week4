using FluentValidation;
using Patika.WebApi.Application.AuthorOperations.Commands.CreateAuthor;


namespace Patika.WebApi.Validation.AuthorValitators
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.DateOfBirth).NotNull();

        }
    }
}
