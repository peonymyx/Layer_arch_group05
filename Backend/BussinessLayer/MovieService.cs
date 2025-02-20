using Backend.CoreLayer;
using Backend.DataAccessLayer;
using Backend.CoreLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend.BussinessLayer
{
    public class MovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        // Create
        public void AddMovie(Movie movie)
        {
            _context.movies.Add(movie);
            _context.SaveChanges();
        }

        // Read
        public Movie GetMovieById(int id)
        {
            return _context.movies.Find(id);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.movies.ToList();
        }

        // Update
        public void UpdateMovie(Movie movie)
        {
            _context.movies.Update(movie);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteMovie(int id)
        {
            var movie = _context.movies.Find(id);
            if (movie != null)
            {
                _context.movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
