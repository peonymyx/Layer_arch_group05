using Backend.CoreLayer;
using Backend.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using MovieSeries.CoreLayer.Entities;

namespace Backend.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class MovieSeriesController : ControllerBase
        {
            private readonly MovieSeriesService _movieSeriesService;

            public MovieSeriesController(MovieSeriesService movieSeriesService)
            {
                _movieSeriesService = movieSeriesService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<MoviesSeries>>> GetAllMoviesSeries()
            {
                var moviesSeries = await _movieSeriesService.GetAllMoviesSeriesAsync();
                return Ok(moviesSeries);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<MoviesSeries>> GetMovieSeriesById(int id)
            {
                var movieSeries = await _movieSeriesService.GetMovieSeriesByIdAsync(id);
                if (movieSeries == null) return NotFound();
                return Ok(movieSeries);
            }

            [HttpPost]
            public async Task<ActionResult> AddMovieSeries([FromBody] MoviesSeries movieSeries)
            {
                await _movieSeriesService.AddMovieSeriesAsync(movieSeries);
                return CreatedAtAction(nameof(GetMovieSeriesById), new { id = movieSeries.Id }, movieSeries);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> UpdateMovieSeries(int id, [FromBody] MoviesSeries movieSeries)
            {
                if (id != movieSeries.Id) return BadRequest();
                await _movieSeriesService.UpdateMovieSeriesAsync(movieSeries);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteMovieSeries(int id)
            {
                await _movieSeriesService.DeleteMovieSeriesAsync(id);
                return NoContent();
            }

            [HttpGet("top-rated/{count}")]
            public async Task<ActionResult<IEnumerable<MoviesSeries>>> GetTopRatedMoviesSeries(int count)
            {
                var moviesSeries = await _movieSeriesService.GetTopRatedMoviesSeriesAsync(count);
                return Ok(moviesSeries);
            }
        }
    }
