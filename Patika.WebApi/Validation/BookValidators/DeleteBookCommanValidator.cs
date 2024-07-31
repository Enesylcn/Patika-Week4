using FluentValidation;
using Patika.WebApi.Application.BookOperations.Commands.DeleteBook;


namespace Patika.WebApi.Validation
{
    public class DeleteBookCommanValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommanValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);

        }
    }
}
