﻿using Backend.CoreLayer;

namespace Backend.DataAccessLayer
{
    public interface IMovieRepository
    {
            Task<IEnumerable<Movie>> GetAllMoviesAsync();
            Task<Movie> GetMovieByIdAsync(int id);
            Task AddMovieAsync(Movie movie);
            Task UpdateMovieAsync(Movie movie);
            Task DeleteMovieAsync(int id);
            Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}
