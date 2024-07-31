using FluentValidation;
using Patika.WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace Patika.WebApi.Validation
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
