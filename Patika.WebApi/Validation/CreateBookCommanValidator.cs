using FluentValidation;
using Patika.WebApi.BookOperations.CreateBook;


namespace Patika.WebApi.Validation
{
    public class CreateBookCommanValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommanValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0); // 0 < GenreId <>
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}
