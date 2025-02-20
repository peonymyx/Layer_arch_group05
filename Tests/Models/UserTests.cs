using Backend.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class UserTests
    {
        [Fact]
        public void User_ShouldRequireUsername()
        {
            // Arrange: Tạo đối tượng User mà không có Username
            var user = new User { email = "john@example.com" }; // Thiếu Username

            // Act: Validate model
            var validationResults = ValidateModel(user);

            // Assert: Kiểm tra có lỗi cho thuộc tính Username
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Username"));
        }

        [Fact]
        public void User_ShouldRequireEmail()
        {
            // Arrange: Tạo đối tượng User mà không có Email
            var user = new User { username = "john_doe" }; // Thiếu Email

            // Act: Validate model
            var validationResults = ValidateModel(user);

            // Assert: Kiểm tra có lỗi cho thuộc tính Email
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Email"));
        }

        // Phương thức hỗ trợ validate model sử dụng DataAnnotations
        private List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
