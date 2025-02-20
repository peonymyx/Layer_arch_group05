using Backend.CoreLayer;
using Backend.DataAccessLayer;
using MovieSeries.CoreLayer.Entities;

namespace Backend.ServiceLayer
{
    public class MovieSeriesService
    {
        private readonly MoviesSeriesRepository _movieSeriesRepository;

        public MovieSeriesService(MoviesSeriesRepository movieSeriesRepository)
        {
            _movieSeriesRepository = movieSeriesRepository;
        }

        public async Task<IEnumerable<MoviesSeries>> GetAllMoviesSeriesAsync()
        {
            return await _movieSeriesRepository.GetAllMoviesSeriesAsync();
        }

        public async Task<MoviesSeries> GetMovieSeriesByIdAsync(int id)
        {
            return await _movieSeriesRepository.GetMoviesSeriesByIdAsync(id);
        }

        public async Task AddMovieSeriesAsync(MoviesSeries movieSeries)
        {
            await _movieSeriesRepository.AddMoviesSeriesAsync(movieSeries);
        }

        public async Task UpdateMovieSeriesAsync(MoviesSeries movieSeries)
        {
            await _movieSeriesRepository.UpdateMoviesSeriesAsync(movieSeries);
        }

        public async Task DeleteMovieSeriesAsync(int id)
        {
            await _movieSeriesRepository.DeleteMoviesSeriesAsync(id);
        }

        public async Task<IEnumerable<MoviesSeries>> GetTopRatedMoviesSeriesAsync(int topCount)
        {
            return await _movieSeriesRepository.GetTopRatedMoviesSeriesWithSpAsync(topCount);
        }
    }
}
