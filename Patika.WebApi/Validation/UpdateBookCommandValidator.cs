using FluentValidation;
using Patika.WebApi.BookOperations.UpdateBook;


namespace Patika.WebApi.Validation
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0); // 0 < GenreId <>
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);

        }
    }
}
