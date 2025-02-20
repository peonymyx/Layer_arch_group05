using Backend.CoreLayer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Repositories
{
    public class MovieRepositoryTests
    {
        private readonly Mock<IMovieRepository> _repositoryMock;

        public MovieRepositoryTests()
        {
            _repositoryMock = new Mock<IMovieRepository>();
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync_WhenMovieIsValid()
        {
            // Arrange
            var movie = new Movie { Title = "Inception", Genre = "Sci-Fi" };
            _repositoryMock.Setup(repo => repo.AddAsync(movie))
                           .Returns(Task.CompletedTask);

            // Act
            await _repositoryMock.Object.AddAsync(movie);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(movie), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfMovies()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie { Title = "Inception", Genre = "Sci-Fi" },
                new Movie { Title = "The Matrix", Genre = "Action" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync())
                           .ReturnsAsync(movies);

            // Act
            var result = await _repositoryMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(movies, result);
        }
    }
}
