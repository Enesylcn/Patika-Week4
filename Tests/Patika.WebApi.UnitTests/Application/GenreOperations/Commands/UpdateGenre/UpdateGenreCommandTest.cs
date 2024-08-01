using FluentAssertions;
using Patika.WebApi.Application.GenreOperations.Commands.UpdateGenre;
using Patika.WebApi.DBOperations;
using TestSetup;
using static Patika.WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var genreId = 4;
            UpdateGenreModel Model = new UpdateGenreModel()
            {
                Name = "WhenAlreadyExistGenreNameIsGiven_InvalidOperation_ShouldBeReturn",
                IsActive = true
            };

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = genreId;
            command.Model = Model;

            var genre = _context.Genres.SingleOrDefault(x => x.Id == genreId);
            //Act & assert 
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı İsimli bir kitap türü zaten mevcut!");


        }

    }
}