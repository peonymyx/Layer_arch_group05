using Backend.CoreLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace Backend.CoreLayer
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
