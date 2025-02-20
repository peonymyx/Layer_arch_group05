using Backend.CoreLayer.Entities;
using Backend.DataAccessLayer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;

        public UserRepositoryTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync_WhenUserIsValid()
        {
            // Arrange
            var user = new User { username = "john_doe", email = "john@example.com" };
            _repositoryMock.Setup(repo => repo.AddUserAsync(user))
                           .Returns(Task.CompletedTask);

            // Act
            await _repositoryMock.Object.AddUserAsync(user);

            // Assert
            _repositoryMock.Verify(repo => repo.AddUserAsync(user), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfUsers()
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
            var result = await _repositoryMock.Object.GetAllUsersAsync();

            // Assert
            Assert.Equal(users, result);
        }
    }
}
