using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class MovieSeriesController
    {
        [ApiController]
        [Route("api/movieseries")]
        public class MovieSeriesController : ControllerBase
        {
            private readonly MovieSeriesService _movieSeriesService;

            public MovieSeriesController(MovieSeriesService movieSeriesService)
            {
                _movieSeriesService = movieSeriesService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<MovieSeries>>> GetAllMovies()
            {
                var movies = await _movieSeriesService.GetAllMoviesAsync();
                return Ok(movies);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<MovieSeries>> GetMovieById(int id)
            {
                var movie = await _movieSeriesService.GetMovieByIdAsync(id);
                if (movie == null) return NotFound();
                return Ok(movie);
            }

            [HttpPost]
            public async Task<IActionResult> CreateMovie(MovieSeries movie)
            {
                await _movieSeriesService.AddMovieAsync(movie);
                return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateMovie(int id, MovieSeries movie)
            {
                if (id != movie.Id) return BadRequest();
                await _movieSeriesService.UpdateMovieAsync(movie);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMovie(int id)
            {
                await _movieSeriesService.DeleteMovieAsync(id);
                return NoContent();
            }
        }
}
