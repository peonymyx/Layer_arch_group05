using System.ComponentModel.DataAnnotations;

namespace Backend.CoreLayer.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
