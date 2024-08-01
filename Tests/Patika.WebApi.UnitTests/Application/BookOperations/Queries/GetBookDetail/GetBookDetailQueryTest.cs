using AutoMapper;
using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Commands.UpdateBook;
using Patika.WebApi.Application.BookOperations.Queries.GetBookDetail;
using Patika.WebApi.DBOperations;
using TestSetup;
using static Patika.WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Qeries.GetBookDetail
{
    public class GetBookDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;


        public GetBookDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var bookId = 4;
            var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
            //Act & assert 
            GetBookDetailQuery command = new GetBookDetailQuery(_context, _mapper);

            command.BookId = bookId;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found");

        }
    }
}