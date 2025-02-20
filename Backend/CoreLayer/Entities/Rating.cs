namespace Backend.CoreLayer.Entities
{
    public class Rating
    {
        public int ReviewId { get; set; }

        public int UserId { get; set; }

        public int MovieSeriesId { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
