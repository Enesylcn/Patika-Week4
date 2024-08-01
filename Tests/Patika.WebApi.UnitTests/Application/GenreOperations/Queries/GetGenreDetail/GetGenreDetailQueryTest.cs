using AutoMapper;
using FluentAssertions;
using Patika.WebApi.Application.BookOperations.Queries.GetBookDetail;
using Patika.WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using Patika.WebApi.DBOperations;
using TestSetup;

namespace Application.GenreOperations.Qeries.GetGenreDetail
{
    public class GetGenreDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;


        public GetGenreDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var genreId = 4;
            var genre = _context.Genres.SingleOrDefault(x => x.Id == genreId);
            //Act & assert 
            GetGenreDetailQuery command = new GetGenreDetailQuery(_context, _mapper);

            command.GenreId = genreId;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");

        }
    }
}