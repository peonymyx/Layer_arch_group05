using Backend.Controllers;
using Backend.CoreLayer.Entities;
using Backend.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { username = "john_doe", email = "john@example.com" },
                new User { username = "jane_doe", email = "jane@example.com" }
            };
            _userServiceMock.Setup(s => s.GetAllUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(users, okResult.Value);
        }

        [Fact]
        public async Task AddUser_ReturnsCreatedAtActionResult_WhenUserIsValid()
        {
            // Arrange
            var user = new User { username = "john_doe", email = "john@example.com" };
            _userServiceMock.Setup(s => s.AddUserAsync(user)).ReturnsAsync(true);

            // Act
            var result = await _controller.AddUser(user);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
