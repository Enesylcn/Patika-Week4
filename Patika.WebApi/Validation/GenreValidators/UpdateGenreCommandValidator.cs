using FluentValidation;
using Patika.WebApi.Application.GenreOperations.Commands.CreateGenre;
using Patika.WebApi.Application.GenreOperations.Commands.UpdateGenre;

namespace Patika.WebApi.Validation
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4).When(x => x.Model.Name != string.Empty);
        }
    }
}
