using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class UserPostLike // Many To Many 'Through' / 'Join' Table
    {
        [Key]
        public int UserPostLikeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */
        public int UserId { get; set; } // FK
        public User User { get; set; }
        public int PostId { get; set; } // Fk
        public Post Post { get; set; }
    }
}