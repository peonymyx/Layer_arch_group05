using MovieSeries.CoreLayer.Entities;

namespace Backend.CoreLayer.Entities
{
    public class MovieSeriesTag
    {
        public int MovieSeriesId { get; set; }
        public int TagId { get; set; }

        public MoviesSeries MovieSeries { get; set; }
        public Tag Tag { get; set; }
    }
}
