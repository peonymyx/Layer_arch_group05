using Backend.CoreLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class ReviewController
    {
        [ApiController]
        [Route("api/reviews")]
        public class ReviewController : ControllerBase
        {
            private readonly ReviewService _reviewService;

            public ReviewController(ReviewService reviewService)
            {
                _reviewService = reviewService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
            {
                var reviews = await _reviewService.GetAllReviewsAsync();
                return Ok(reviews);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Review>> GetReviewById(int id)
            {
                var review = await _reviewService.GetReviewByIdAsync(id);
                if (review == null) return NotFound();
                return Ok(review);
            }

            [HttpPost]
            public async Task<IActionResult> CreateReview(Review review)
            {
                await _reviewService.AddReviewAsync(review);
                return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateReview(int id, Review review)
            {
                if (id != review.Id) return BadRequest();
                await _reviewService.UpdateReviewAsync(review);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteReview(int id)
            {
                await _reviewService.DeleteReviewAsync(id);
                return NoContent();
            }
        }
}
