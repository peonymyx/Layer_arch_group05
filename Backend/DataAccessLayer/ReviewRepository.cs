using Backend.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessLayer
{
    public class ReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all reviews
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        // Get reviews for a specific movie
        public async Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(int movieId)
        {
            return await _context.Reviews
                .Where(r => r.MovieId == movieId)
                .ToListAsync();
        }

        // Add a new review
        public async Task AddReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        // Update a review
        public async Task UpdateReviewAsync(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        // Delete a review
        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

        // Call stored procedure to get reviews for a movie
        public async Task<IEnumerable<Review>> GetReviewsForMovieWithSpAsync(int movieId)
        {
            return await _context.Reviews
                .FromSqlRaw("EXEC GetReviewsForMovie @movie_id = {0}", movieId)
                .ToListAsync();
        }
    }
}
