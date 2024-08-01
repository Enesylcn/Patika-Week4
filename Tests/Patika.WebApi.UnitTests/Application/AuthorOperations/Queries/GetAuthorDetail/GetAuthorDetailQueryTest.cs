using AutoMapper;
using FluentAssertions;
using Patika.WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Patika.WebApi.DBOperations;
using TestSetup;

namespace Application.AuthorOperations.Qeries.GetAuthorDetail
{
    public class GetAuthorDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;


        public GetAuthorDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistAuthorIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var authorId = 4;
            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            //Act & assert 
            GetAuthorDetailQuery command = new GetAuthorDetailQuery(_context, _mapper);

            command.AuthorId = authorId;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author not found!");

        }
    }
}