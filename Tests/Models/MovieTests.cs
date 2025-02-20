using Backend.CoreLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class MovieTests
    {
        [Fact]
        public void Movie_ShouldRequireTitle()
        {
            // Arrange: Tạo đối tượng Movie mà không có Title
            var movie = new Movie { Genre = "Sci-Fi" }; // Thiếu Title

            // Act: Validate model
            var validationResults = ValidateModel(movie);

            // Assert: Kiểm tra có lỗi cho thuộc tính Title
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Title"));
        }

        [Fact]
        public void Movie_ShouldRequireGenre()
        {
            // Arrange: Tạo đối tượng Movie mà không có Genre
            var movie = new Movie { Title = "Inception" }; // Thiếu Genre

            // Act: Validate model
            var validationResults = ValidateModel(movie);

            // Assert: Kiểm tra có lỗi cho thuộc tính Genre
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Genre"));
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
