namespace Backend.CoreLayer.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int MovieSeriesId { get; set; }
        public decimal RatingValue { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
