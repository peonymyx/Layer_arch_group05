﻿using System.ComponentModel.DataAnnotations;

namespace Backend.CoreLayer.Entities
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        public string username { get; set; }
        public string email { get; set; }
        public DateTime? created_at { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
