using Backend.BussinessLayer;
using Backend.CoreLayer.Entities;
using Backend.DataAccessLayer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_repositoryMock.Object);
        }

        [Fact]
        public async Task AddUserAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var user = new User { username = "john_doe", email = "john@example.com" };
            _repositoryMock.Setup(repo => repo.AddUserAsync(user))
                           .ReturnsAsync(true);

            // Act
            var result = await _userService.AddUserAsync(user);

            // Assert
            _repositoryMock.Verify(repo => repo.AddUserAsync(user), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnListOfUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { username = "john_doe", email = "john@example.com" },
                new User { username = "jane_doe", email = "jane@example.com" }
            };
            _repositoryMock.Setup(repo => repo.GetAllUsersAsync())
                           .ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.Equal(users, result);
        }
    }
}
