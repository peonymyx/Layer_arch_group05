using Backend.BussinessLayer;
using Backend.CoreLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Controllers
{
    public class MovieControllerTests
    {
        private readonly Mock<IMovieService> _serviceMock;
        private readonly MovieController _controller;

        public MovieControllerTests()
        {
            _serviceMock = new Mock<IMovieService>();
            _controller = new MovieController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetMovies_ReturnsOkResult_WithListOfMovies()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie { Title = "Inception", Genre = "Sci-Fi" },
                new Movie { Title = "The Matrix", Genre = "Action" }
            };
            _serviceMock.Setup(s => s.GetAllMoviesAsync()).ReturnsAsync(movies);

            // Act
            var result = await _controller.GetMovies();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(movies, okResult.Value);
        }

        [Fact]
        public async Task AddMovie_ReturnsCreatedAtActionResult_WhenMovieIsValid()
        {
            // Arrange
            var movie = new Movie { Title = "Inception", Genre = "Sci-Fi" };
            _serviceMock.Setup(s => s.AddMovieAsync(movie)).ReturnsAsync(true);

            // Act
            var result = await _controller.AddMovie(movie);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
