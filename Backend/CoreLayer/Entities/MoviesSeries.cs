using Backend.CoreLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    public class MoviesSeries
    {
        [Key]
        [Column("movie_series_id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("genre")]
        public string Genre { get; set; }

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<MovieSeriesTag> MoviesSeriesTags { get; set; } = new List<MovieSeriesTag>();
    }
}