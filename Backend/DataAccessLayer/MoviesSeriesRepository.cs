using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;

namespace Backend.DataAccessLayer
{
    public class MoviesSeriesRepository
    {
        private readonly AppDbContext _context;

        public MoviesSeriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MoviesSeries>> GetAllMoviesSeriesAsync()
        {
            return await _context.MoviesSeries.ToListAsync();
        }

        public async Task<MoviesSeries> GetMoviesSeriesByIdAsync(int id)
        {
            return await _context.MoviesSeries
                .Include(ms => ms.Reviews)
                .Include(ms => ms.Ratings)
                .Include(ms => ms.MoviesSeriesTags)
                .ThenInclude(mst => mst.Tag)
                .FirstOrDefaultAsync(ms => ms.Id == id);
        }

        public async Task AddMoviesSeriesAsync(MoviesSeries MoviesSeries)
        {
            await _context.MoviesSeries.AddAsync(MoviesSeries);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMoviesSeriesAsync(MoviesSeries MoviesSeries)
        {
            _context.MoviesSeries.Update(MoviesSeries);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMoviesSeriesAsync(int id)
        {
            var MoviesSeries = await _context.MoviesSeries.FindAsync(id);
            if (MoviesSeries != null)
            {
                _context.MoviesSeries.Remove(MoviesSeries);
                await _context.SaveChangesAsync();
            }
        }

        // Stored Procedure Calls
        public async Task<IEnumerable<MoviesSeries>> GetTopRatedMoviesSeriesWithSpAsync(int topCount)
        {
            return await _context.MoviesSeries
                .FromSqlRaw("EXEC GetTopRatedMoviesSeries @top_count = {0}", topCount)
                .ToListAsync();
        }
    }
}
