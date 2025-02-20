using Backend.CoreLayer.Entities;

namespace Backend.BussinessLayer
{
    public class RatingService
    {
        public static decimal CalculateAverageRating(IEnumerable<Rating> ratings)
        {
            if (ratings == null || !ratings.Any())
                return 0;
            return ratings.Average(r => r.RatingValue);
        }
    }
}
