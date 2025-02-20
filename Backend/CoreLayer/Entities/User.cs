using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.CoreLayer.Entities
{
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
