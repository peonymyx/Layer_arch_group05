using Backend.CoreLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class RatingController
    {
        //[ApiController]
        //[Route("api/ratings")]
        //public class RatingController : ControllerBase
        //{
        //    private readonly RatingService _ratingService;

        //    public RatingController(RatingService ratingService)
        //    {
        //        _ratingService = ratingService;
        //    }

        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<Rating>>> GetAllRatings()
        //    {
        //        var ratings = await _ratingService.GetAllRatingsAsync();
        //        return Ok(ratings);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> AddRating(Rating rating)
        //    {
        //        await _ratingService.AddRatingAsync(rating);
        //        return CreatedAtAction(nameof(GetAllRatings), rating);
        //    }
        //}
    }
}
