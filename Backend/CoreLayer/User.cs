﻿namespace Backend.CoreLayer
{
    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime? created_at { get; set; }
    }
}
