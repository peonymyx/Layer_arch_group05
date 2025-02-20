using MovieSeries.CoreLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.CoreLayer.Entities
{
    public class Review
    {
        [Column("review_id")]
        public int Id { get; set; }

        [Column("movie_series_id")]
        public int MovieId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("review_text")]
        public string ReviewText { get; set; }

        [Column("review_date")]
        public DateTime ReviewDate { get; set; }

        // Khai báo khóa ngoại rõ ràng
        [ForeignKey("MovieId")]
        public MoviesSeries MovieSeries { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
