using Backend.BussinessLayer;
using Backend.CoreLayer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _repositoryMock;
        private readonly MovieService _movieService;

        public MovieServiceTests()
        {
            _repositoryMock = new Mock<IMovieRepository>();
            _movieService = new MovieService(_repositoryMock.Object);
        }

        [Fact]
        public async Task AddMovieAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var movie = new Movie { Title = "Inception", Genre = "Sci-Fi" };
            _repositoryMock.Setup(repo => repo.AddAsync(movie))
                           .ReturnsAsync(true);

            // Act
            var result = await _movieService.AddMovieAsync(movie);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(movie), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllMoviesAsync_ShouldReturnListOfMovies()
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
            var result = await _movieService.GetAllMoviesAsync();

            // Assert
            Assert.Equal(movies, result);
        }
    }
}
