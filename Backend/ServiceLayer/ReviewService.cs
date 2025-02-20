using Backend.CoreLayer.Entities;
using Backend.DataAccessLayer;

namespace Backend.ServiceLayer
{
    public class ReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // Get all reviews
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllReviewsAsync();
        }

        // Get reviews for a specific movie
        public async Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(int movieId)
        {
            return await _reviewRepository.GetReviewsByMovieIdAsync(movieId);
        }

        // Add a new review
        public async Task AddReviewAsync(Review review)
        {
            await _reviewRepository.AddReviewAsync(review);
        }

        // Update a review
        public async Task UpdateReviewAsync(Review review)
        {
            await _reviewRepository.UpdateReviewAsync(review);
        }

        // Delete a review
        public async Task DeleteReviewAsync(int id)
        {
            await _reviewRepository.DeleteReviewAsync(id);
        }

        // Call stored procedure to get reviews for a movie
        public async Task<IEnumerable<Review>> GetReviewsForMovieWithSpAsync(int movieId)
        {
            return await _reviewRepository.GetReviewsForMovieWithSpAsync(movieId);
        }
    }
}
