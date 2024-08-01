using FluentAssertions;
using Patika.WebApi;
using Patika.WebApi.Application.GenreOperations.Commands.DeleteGenre;
using Patika.WebApi.DBOperations;
using TestSetup;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var genreId = 4;
            Genre genre = _context.Genres.SingleOrDefault(x => x.Id == genreId);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            //Act & assert 
            DeleteGenreCommand command = new DeleteGenreCommand(_context);

            command.GenreId = genreId;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü Bulunamadı!");

        }
    }
}