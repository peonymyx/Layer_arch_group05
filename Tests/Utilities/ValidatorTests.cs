using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tests.Utilities
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("test@example.com", true)]
        [InlineData("invalidemail", false)]
        [InlineData("user@domain", false)]
        [InlineData("user@domain.com", true)]
        public void IsValidEmail_ShouldReturnExpectedResult(string email, bool expected)
        {
            // Act
            bool result = Validator.IsValidEmail(email);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
