using AutoMapper;
using FluentAssertions;
using Patika.WebApi;
using Patika.WebApi.Application.GenreOperations.Commands.CreateGenre;
using Patika.WebApi.DBOperations;
using TestSetup;
using static Patika.WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public CreateGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //Arrange 
            var genre = new Genre() { Name = "Test_WhenAlreadyExistGenreTitleIsGiven_InvalidOperation_ShouldBeReturn", IsActive = true };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreModel() { Name = genre.Name, };

            //Act & assert 
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü zaten mevcut!");

        }

    }
}