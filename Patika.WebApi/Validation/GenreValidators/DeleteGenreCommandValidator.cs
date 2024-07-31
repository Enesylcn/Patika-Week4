using FluentValidation;
using Patika.WebApi.Application.GenreOperations.Commands.DeleteGenre;

namespace Patika.WebApi.Validation
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}
